module.exports = (app) => {
    const campuses = require('../controllers/campus.js');

    // Create a new Note
    app.post('/campuses', campuses.create);

    // Retrieve all Notes
    app.get('/campuses', campuses.findAll);

    // Retrieve a single Note with noteId
    app.get('/campuses/:campusId', campuses.findOne);

    // Update a Note with noteId
    app.put('/campuses/:campusId', campuses.update);

    // Delete a Note with noteId
    app.delete('/campuses/:campusId', campuses.delete);
}