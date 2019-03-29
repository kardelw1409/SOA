const Room = require('./room/room.model');
const campuses = require('./campus/campus.controller');

exports.create = (req, res) => {
    // Validate request
    if (!req.body.number) {
        return res.status(400).send({
            message: "Room content can not be empty"
        });
    }
    if (!req.body.place_count) {
        return res.status(400).send({
            message: "Room content can not be empty"
        });
    }

    if (!req.body._campus_id) {
        return res.status(400).send({
            message: "Room content can not be empty"
        });
    }
    // Create a Room
    const room = new Room({
        number: req.body.number,
        place_count: req.body.place_count,
        _campus_id: req.body._campus_id,
        campuses: Campus.findById(req.params._campus_id)
    });

    // Save Room in the database
    room.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while creating the Room."
            });
        });
};

// Retrieve and return all rooms from the database.
exports.findAll = (req, res) => {
    Room.find()
        .then(rooms => {
            res.send(rooms);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving rooms."
            });
        });
};

// Find a single room with a roomId
exports.findOne = (req, res) => {
    Room.findById(req.params.roomId)
        .then(room => {
            if (!room) {
                return res.status(404).send({
                    message: "Room not found with id " + req.params.roomId
                });
            }
            res.send(room);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Room not found with id " + req.params.roomId
                });
            }
            return res.status(500).send({
                message: "Error retrieving room with id " + req.params.roomId
            });
        });
};

// Update a room identified by the roomId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.number) {
        return res.status(400).send({
            message: "Room content can not be empty"
        });
    }
    if (!req.body.adress) {
        return res.status(400).send({
            message: "Room content can not be empty"
        });
    }
    // Find note and update it with the request body
    Room.findByIdAndUpdate(req.params.roomId, {
        number: req.body.number,
        place_count: req.body.adress,
        _campus_id: req.body._campus_id,
        campuses: Campus.findById(req.params._campus_id)
    }, { new: true })
        .then(room => {
            if (!room) {
                return res.status(404).send({
                    message: "Room not found with id " + req.params.roomId
                });
            }
            res.send(room);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Room not found with id " + req.params.roomId
                });
            }
            return res.status(500).send({
                message: "Error updating room with id " + req.params.roomId
            });
        });
};

// Delete a room with the specified roomId in the request
exports.delete = (req, res) => {
    Room.findByIdAndRemove(req.params.roomId)
        .then(room => {
            if (!room) {
                return res.status(404).send({
                    message: "Room not found with id " + req.params.roomId
                });
            }
            res.send({ message: "Room deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Room not found with id " + req.params.roomId
                });
            }
            return res.status(500).send({
                message: "Could not delete room with id " + req.params.roomId
            });
        });
};
