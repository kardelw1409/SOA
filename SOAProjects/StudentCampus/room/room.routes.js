module.exports = (app) => {
    const rooms = require('./../room/room.controller');//

    // Create a new Room
    app.post('/Room', rooms.create);

    // Retrieve all Rooms
    app.get('/Room', rooms.findAll);

    // Retrieve a single Rome with roomId
    app.get('/Room/:roomId', rooms.findOne);

    // Update a Room with roomId
    app.put('/Room/:roomId', rooms.update);

    // Delete a Room with roomId
    app.delete('/Room/:roomsId', rooms.delete);
}