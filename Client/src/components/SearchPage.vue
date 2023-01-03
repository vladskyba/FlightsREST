<template>

  <div class="container">
    <form @submit.prevent="searchFlights">
          <div class="row">
              <div class="col-4">Departure</div>
              <div class="col-4">Arrival</div>
              <div class="col-2">Departure Start</div>
              <div class="col-2">Departure End</div>
          </div>

          <div class="row">
              <div class="col-4">
                 <input type="text" class="form-control" v-model="searchFilters.departure">
              </div>
              <div class="col-4">
                <input type="text" class="form-control" v-model="searchFilters.arrival">
              </div>
              <div class="col-2">
                  <input type="datetime-local" class="form-control" v-model="searchFilters.startArrival">
              </div>
              <div class="col-2">
                  <input type="datetime-local" class="form-control" v-model="searchFilters.endArrival">
              </div>
          </div>

          <input type="submit" value="Search" class="btn btn-dark w-100 mt-lg-2 mt-0" />
    </form>
  </div>

  <section class="container" v-if="flights.length > 0">
    <SearchTable :flights="flights" />
  </section>

</template>

<script>
import Modal from './Modal.vue';
import SearchTable from './SearchTable.vue';

export default {
  name: 'FlightsSearch',
  components: {
    Modal,
    SearchTable
  },
  
  data(){
    return{
        searchFilters:{
            departure: null,
            arrival: null,
            departureStart: null,
            departureEnd: null
        },
        airports: [],
        flights: []
    }
  },
  methods: {
    async searchFlights() {        
        const searchedFlights = (await this.$api.flight.searchFlights(
          {
            departure: this.searchFilters.departure,
            arrival: this.searchFilters.arrival
          }
        )).data;

        this.flights = searchedFlights.map(record => {
          return { 
            ...record
          }
        });
    }
  },
}
</script>