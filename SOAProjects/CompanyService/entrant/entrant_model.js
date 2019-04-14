const mongoose = require('mongoose');
const Schema = mongoose.Schema;
//const CompanySchema = require('../campus/campus_model');

const EntrantSchema = new Schema({
    medal: { type: Boolean, required: true },
    total_score: { type: Number, required: true },
    is_entranted: { type: Boolean, required: true },
    entrant_year: { type: Number, required: true },
    owner: {
        model: 'Profile',
        unique: true
    }
   /// _speciality_id: { type: Schema.Types.ObjectId, ref: 'brbrbbr' }
});

module.exports = mongoose.model('Entrant', EntrantSchema);