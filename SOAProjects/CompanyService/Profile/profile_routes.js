module.exports = (app) => {
    //require('module-alias/register');
    const campuses = require('./profele_controller');//

    // Create a new Campus
    app.post('/Profile', campuses.create);

    // Retrieve all Campuses
    app.get('/Profile', campuses.findAll);

    // Retrieve a single Campus with campusId
    app.get('/Profile/:profilesId', campuses.findOne);

    // Update a Campus with campusId
    app.put('/Profile/:profilesId', campuses.update);

    // Delete a Campus with campusId
    app.delete('/Profile/:profilesId', campuses.delete);
}