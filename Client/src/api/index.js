import flightModule from './flight'
import bookingModule from './booking'
import axios from 'axios'

const instance = axios.create({
  baseURL: 'http://localhost:5001',
  withCredentials: false,
  headers: {
    accept: 'application/json'  
  }
})

export default{
  flight: flightModule(instance),
  booking: bookingModule(instance),
}