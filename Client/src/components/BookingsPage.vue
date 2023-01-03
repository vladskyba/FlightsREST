<template>

  <h1>Резервування користувача Rambls</h1>

  <section class="container" v-if="reservations.length > 0">
    <table class="table table-bordered">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Departure</th>
      <th scope="col">Arrival</th>
      <th scope="col">Cost</th>
      <th scope="col">Tickets</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="(item, idx) of reservations" :key="item.id">
      <th> {{ idx + 1 }}</th>
      <td> {{ [item.flight.departure, item.flight.arrivalDateTime].join(", ") }}</td>
      <td> {{ [item.flight.arrival, item.flight.departureDateTime].join(", ") }}</td>
      <td> {{ item.flight.cost }} USD</td>
      <td> 
        <div v-for="(item, idx) of item.tickets" :key="item.id">
            Ticket #{{idx + 1}}: Line - {{item.line}}, Seat - {{item.seat}}
        </div>
      </td>
    </tr>
  </tbody>
</table>
  </section>

</template>

<script>
import Modal from './Modal.vue';

export default {
  name: 'Reservations',
  components: {
    Modal
  },
  
  data(){
    return{
        reservations: []
    }
  },
  created(){
    this.$load(async() => {

        const searchedReservations = (await this.$api.booking.getByUser(1)).data;

        console.log(searchedReservations);
        this.reservations = searchedReservations.map(record => { return { ...record }});
    })
  }
}
</script>