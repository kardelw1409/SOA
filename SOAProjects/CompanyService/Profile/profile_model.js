const mongoose = require('mongoose');
const Schema = mongoose.Schema;
//const EntrantSchema = require('../entrant/entrant_model');

const ProfileSchema = new Schema({
    _id: Number,
    first_name: { type: String, required: true },
    last_name: { type: String, required: true },
    patronymic: { type: String, required: true },
    birthday: { type: String, required: true },
   // _entrant_id: { type: Schema.Types.ObjectId, ref: 'Entrant'}
});


module.exports = mongoose.model('Profile', ProfileSchema);