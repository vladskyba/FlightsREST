<template>
    <section class="container">
    <div class="row justify-content-center">
        <div class="col-lg-8">
            <div class="bg-white text-left">
                <h1>Зробити резервування на рейс {{flightId}}</h1> <br/>
                <p1>Користувач: {{ userName }}</p1>
                <form @submit.prevent="createBooking">
                    <div class="form-group">
                        <input type="text" class="form-control mt-2 mb-4" placeholder="Email" v-model="reservation.email"> 
                        <h3>Квитки</h3>

                        <div class ="container mt-4"> 
                          <div class="card">
                            <div class="card-body">
                              <div v-for="(item, idx) of tickets" :key="item">
                              <h3>Квиток #{{ idx + 1 }} </h3>
                              <div class="row mt-4">
                                <div class="col-sm-5">
                                  <label>Місце</label>
                                  <input type="number" class="form-control" v-model="item.seat">
                                </div>
                                <div class="col-sm-5">
                                    <label label>Ряд</label>
                                    <input type="number" class="form-control" v-model="item.line">
                                </div>
                                <div class="col-sm-2 pt-4">
                                  <buttom type="button" class="btn btn-dark ml-2" @click="addTicket">+</buttom>
                                 <buttom type="button" class="btn btn-dark mr-2">x</buttom>
                                </div>
                              </div>
                          </div>
                      </div>
                    </div>
                    
                    </div>
                        <input type="submit" value="Зарезервувати" class="btn btn-dark w-100 mt-lg-2" />
                    </div>
                </form>

            </div>
        </div>
    </div>
  </section>
</template>

<script>
import Modal from './Modal.vue';
import {reactive } from '@vue/reactivity'
import {useRoute} from "vue-router";

export default {
  name: 'ReservationInsert',
  components: {
    Modal,
  },
    setup(){
    const tickets = reactive([
        { line: 0, seat: 0}
    ])

    const addTicket = () => {
      tickets.push({line: 0, seat: 0})
    }

    const route = useRoute();

    return {
        tickets,
        addTicket
    }
  },
  data(){
    return{
        reservation:{
            userId : 1,
            email : null,
        },
        userName: "Rambls",
        flightId: null
    }
  },
  methods: {
    async createBooking() {
      console.log(this.$route.params.id);
      console.log(this.tickets);
      await this.$api.booking.createBooking({
          flightId: this.$route.params.id,
          bookingStatus: 0,
          email: this.reservation.email,
          userId: parseInt(this.reservation.userId),
          tickets : this.tickets
      })
    }
  }
}
</script>