module.exports = (app) => {
    //require('module-alias/register');
    const campuses = require('./entrant_controller');//

    // Create a new Campus
    app.post('/Entrant', entrantes.create);

    // Retrieve all Campuses
    app.get('/Entrant', entrantes.findAll);

    // Retrieve a single Campus with campusId
    app.get('/Entrant/:entrantId', entrantes.findOne);

    // Update a Campus with campusId
    app.put('/Entrant/:entrantId', entrantes.update);

    // Delete a Campus with campusId
    app.delete('/Entrant/:entrantId', entrantes.delete);
}