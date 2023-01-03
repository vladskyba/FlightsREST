export default function(instance) {
    return {
        createBooking(payload){
            return instance.post('/createBooking', payload)
        },
        getByUser(id){
            return instance.get('/getByUser', { params: { userId: id }})
        }
    }
}