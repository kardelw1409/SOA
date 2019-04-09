module.exports = (app) => {
    //require('module-alias/register');
    const profiles = require('./profile_controller');//

    // Create a new Campus
    app.post('/Profile', profiles.create);

    // Retrieve all Campuses
    app.get('/Profile', profiles.findAll);

    // Retrieve a single Campus with campusId
    app.get('/Profile/:profilesId', profiles.findOne);

    // Update a Campus with campusId
    app.put('/Profile/:profilesId', profiles.update);

    // Delete a Campus with campusId
    app.delete('/Profile/:profilesId', profiles.delete);
}