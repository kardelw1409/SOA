var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var CampusSchema = new Schema({
    adress: String
});


// Export the model
module.exports = mongoose.model('Campus', CampusSchema);