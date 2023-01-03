import { createRouter, createWebHistory } from "vue-router";
import FlightInsert from '../components/FlightAdd.vue'
import FlightSearch from '../components/SearchPage.vue'
import ReservationInsert from '../components/BookingAdd.vue'
import ReservationsPage from '../components/BookingsPage.vue'

export default createRouter({
    history: createWebHistory(),
    routes: [
        { 
          path: '/flight',
          name: 'flight-insert', 
          component: FlightInsert
        },
        { path: '/flightsSearch',
        name: 'flights-search',
        component: FlightSearch
        },
        {
          path: '/createReservation/:id',
          name: 'reservation-insert',
          component: ReservationInsert
        },
        {
          path: '/reservations',
          name: 'reservations',
          component: ReservationsPage
        }
    ]
})