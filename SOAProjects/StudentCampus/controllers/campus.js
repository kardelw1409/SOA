const Campus = require('../models/campus.js');

// Create and Save a new Note
exports.create = (req, res) => {
    // Validate request
    if (!req.body.content) {
        return res.status(400).send({
            message: "Campus content can not be empty"
        });
    }

    // Create a Note
    const campus = new Campus({
        adress: req.body.adress || "Untitled campus"
    });

    // Save Note in the database
    campus.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while creating the Note."
            });
        });
};

// Retrieve and return all notes from the database.
exports.findAll = (req, res) => {
    Campus.find()
        .then(campuses => {
            res.send(campuses);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving notes."
            });
        });
};

// Find a single note with a noteId
exports.findOne = (req, res) => {
    Campus.findById(req.params.noteId)
        .then(campus => {
            if (!campus) {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });
            }
            res.send(campus);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });
            }
            return res.status(500).send({
                message: "Error retrieving note with id " + req.params.noteId
            });
        });
};

// Update a note identified by the noteId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.content) {
        return res.status(400).send({
            message: "Note content can not be empty"
        });
    }

    // Find note and update it with the request body
    Campus.findByIdAndUpdate(req.params.noteId, {
        adress: req.body.adress || "Untitled Note"
    }, { new: true })
        .then(campus => {
            if (!campus) {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });
            }
            res.send(campus);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });
            }
            return res.status(500).send({
                message: "Error updating note with id " + req.params.noteId
            });
        });
};

// Delete a note with the specified noteId in the request
exports.delete = (req, res) => {
    Campus.findByIdAndRemove(req.params.campusId)
        .then(campus => {
            if (!campus) {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.noteId
                });
            }
            res.send({ message: "Note deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Note not found with id " + req.params.campusId
                });
            }
            return res.status(500).send({
                message: "Could not delete note with id " + req.params.campusId
            });
        });
};