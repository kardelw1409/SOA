module.exports = (app) => {
    const campuses = require('../campus/campus.controller');//
                               
    // Create a new Campus
    app.post('/Campus', campuses.create);

    // Retrieve all Campuses
    app.get('/Campus', campuses.findAll);

    // Retrieve a single Campus with campusId
    app.get('/Campus/:campusId', campuses.findOne);

    // Update a Campus with campusId
    app.put('/Campus/:campusId', campuses.update);

    // Delete a Campus with campusId
    app.delete('/Campus/:campusId', campuses.delete);
}