import Vue from 'vue'
import Router from 'vue-router'
import VacancyTable from '@/components/VacancyTable'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: VacancyTable
    }
  ]
})
