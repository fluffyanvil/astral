<template>
  <v-card>
    <v-card-title>
      <v-spacer></v-spacer>
      <v-text-field
        append-icon="search"
        label="Поиск"
        single-line
        hide-details
        v-model="search"
      ></v-text-field>
    </v-card-title>
    <v-data-table :headers="headers" :loading="this.isBusy" :items="items" hide-actions class="elevation-1" :search="search" no-data-text="Нет данных">
      <v-progress-linear slot="progress" color="blue" indeterminate></v-progress-linear>
      <template slot="items" slot-scope="props">
        <tr @click="props.expanded = !props.expanded">
            <td>{{ props.item.title }}</td>
            <td class="text-xs-right">{{ props.item.salaryFrom }}</td>
            <td class="text-xs-right">{{ props.item.salaryTo }}</td>
            <td class="text-xs-right">{{ props.item.organization }}</td>
            <td class="text-xs-right">{{ props.item.organizationUrl }}</td>
            <td class="text-xs-right">{{ props.item.contactPerson }}</td>
            <td class="text-xs-right">{{ props.item.contactPhone }}</td>
            <td class="text-xs-right">{{ props.item.contactEmail }}</td>
            <td class="text-xs-right">
              <v-switch color="blue" v-model=props.item.isFavourite @click.stop="changeIsFavourite(props.item)"></v-switch>
            </td>
        </tr>
      </template>
      <v-alert slot="no-results" :value="true" color="error" icon="warning">
        По запросу "{{ search }}" ничего не найдено.
      </v-alert>
      <template slot="expand" slot-scope="props">
        <v-card flat>
          <v-card-text>{{props.item.description}}</v-card-text>
        </v-card>
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
  import axios from 'axios';
  export default {
    methods: {
      load: function() {
          this.isBusy = true;
          axios
            .get('http://localhost:57571/api/Vacancies')
            .then(({data}) => {
                this.items = data;
                this.isBusy = false;
            })
            .catch((err) => {
                console.log(err);
                this.isBusy = true;
            });
      },
      update: function(item){
          this.isBusy = true;
          axios
            .get('http://localhost:57571/api/Vacancies/' + item.id)
            .then(({data}) => {
                this.isBusy = false;
                item.isFavourite = data.isFavourite;
            })
            .catch((err) => {
                console.log(err);
                this.isBusy = true;
            });
      },
      changeIsFavourite: function(item){
          this.isBusy = true;
          axios
            .post('http://localhost:57571/api/Vacancies', item)
            .then(({data}) => {
                this.isBusy = false;
                this.update(item);
            })
            .catch((err) => {
                console.log(err);
                this.isBusy = true;
            });
      }
    },
    mounted: function() {
      this.load();
    },
    data() {
      return {
        search: '',
        isBusy: false,
        headers: [{
            text: 'Название',
            align: 'left',
            sortable: false,
            value: 'title'
          },
          {
            text: 'Зарплата от',
            value: 'salaryFrom'
          },
          {
            text: 'Зарплата до',
            value: 'salaryTo'
          },
          {
            text: 'Работодатель',
            value: 'organization'
          },
          {
            text: 'Url',
            value: 'organizationUrl'
          },
          {
            text: 'Контактное лицо',
            value: 'contactPerson'
          },
          {
            text: 'Телефон',
            value: 'contactPhone'
          },
          {
            text: 'Email',
            value: 'contactEmail'
          },
          {
            text: 'Избранное',
            value: 'isFavourite'
          }
        ],
        items: [ ]
      }
    }
  }
</script>

