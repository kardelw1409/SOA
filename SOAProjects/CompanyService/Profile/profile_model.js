const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const ProfileSchema = new Schema({
    first_name: { type: String, required: true },
    last_name: { type: String, required: true },
    patronymic: { type: String, required: true },
    birthday: { type: String, required: true }
   // rooms: [{ type: Schema.Types.ObjectId, ref: 'Room' }]
});


module.exports = mongoose.model('Profile', ProfileSchema);