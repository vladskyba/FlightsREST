<template>
    <section class="container">
    <Teleport to="body">
      <modal :show="showModal" @close="showModal = false">
        <template #header>
          <h3>{{modalMessage}}</h3>
        </template>
      </modal>
    </Teleport>
    <div class="row justify-content-center">
        <div class="col-lg-4">
            <div class="bg-white text-left">
                <p1>Створити авіарейс</p1>
                <form @submit.prevent="createFlight">
                    <div class="form-group">
                        <p class="bottomn">Виберіть аеропорт відправлення</p>
                        <input type="text" class="form-control" placeholder="Аеропорт відправлення" v-model="information.departure">
                    </div>
                    <div class="form-group">
                        <label for="arrivalTime" class="input-label"> Час відправлення</label>
                        <input type="datetime-local" class="form-control" placeholder="Час приземлення" v-model="information.arrivalDateTime">
                    </div>
                    <div class="form-group">
                      <p class="bottomn">Виберіть аеропорт призначення</p>
                        <input type="text" class="form-control" placeholder="Аеропорт призначення" v-model="information.arrival">
                    </div>
                    <div class="form-group">
                      <label for="arrivalTime" class="input-label"> Час приземлення</label>
                        <input type="datetime-local" class="form-control" placeholder="Час вильоту" v-model="information.departureDateTime">
                    </div>
                    <div class="form-group">
                        <label for="cost" class="input-label"></label>
                        <input type="text" class="form-control" placeholder="Ціна рейсу" v-model="information.cost">
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Створити авіарейс" class="btn btn-dark w-100 mt-lg-2" />
                    </div>
                </form>
            </div>
        </div>
    </div>
  </section>
</template>

<script>
import Modal from './Modal.vue';

export default {
  name: 'Flight',
  components: {
    Modal
  },
  
  data(){
    return{
        information: {
            departure: null,
            arrival: null,
            arrivalDateTime : null,
            departureDateTime: null,
            cost : null,
            isActive: null
        },
        modalMessage: null,
        showModal: false
    }
  },
  methods: {
    async createFlight() {
        try {
            console.log(this.information)

            await this.$api.flight.createFlight({
                departure: this.information.departure,
                arrival: this.information.arrival,
                departureDateTime: this.information.departureDateTime,
                arrivalDateTime: this.information.arrivalDateTime,
                cost : parseFloat(this.information.cost),
                isActive : true
            })

            this.modalMessage = "Авіарейс успішно створено!"
            this.showModal = true;

            this.information.departure = null;
            this.information.arrival = null;
            this.information.departureDateTime = null;
            this.information.arrivalDateTime = null;
            this.information.cost = null;
        }catch(error) {
            this.modalMessage = error.response.data
            this.showModal = true;
        }
    }
  },
}
</script>