const Campus = require('../campus/campus.model');

// Create and Save a new Campus
exports.create = (req, res) => {
    // Validate request
    if (!req.body.number) {
        return res.status(400).send({
            message: "Campus content can not be empty"
        });
    }
    if (!req.body.adress) {
        return res.status(400).send({
            message: "Campus content can not be empty"
        });
    }
    // Create a Campus
    const campus = new Campus({
        number: req.body.number,
        adress: req.body.adress
    });

    // Save Campus in the database
    campus.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while creating the Campus."
            });
        });
};

// Retrieve and return all campuses from the database.
exports.findAll = (req, res) => {
    Campus.find()
        .then(campuses => {
            res.send(campuses);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving campuses."
            });
        });
};

// Find a single campus with a campusId
exports.findOne = (req, res) => {
    Campus.findById(req.params.campusId)
        .then(campus => {
            if (!campus) {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.campusId
                });
            }
            res.send(campus);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.campusId
                });
            }
            return res.status(500).send({
                message: "Error retrieving campus with id " + req.params.campusId
            });
        });
};

// Update a note identified by the noteId in the request
exports.update = (req, res) => {
    // Validate Request
    if (!req.body.number) {
        return res.status(400).send({
            message: "Campus content can not be empty"
        });
    }
    if (!req.body.adress) {
        return res.status(400).send({
            message: "Campus content can not be empty"
        });
    }
    // Find campus and update it with the request body
    Campus.findByIdAndUpdate(req.params.campusId, {
        number: req.body.number,
        adress: req.body.adress
    }, { new: true })
        .then(campus => {
            if (!campus) {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.campusId
                });
            }
            res.send(campus);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.campusId
                });
            }
            return res.status(500).send({
                message: "Error updating campus with id " + req.params.campusId
            });
        });
};

// Delete a campus with the specified campusId in the request
exports.delete = (req, res) => {
    Campus.findByIdAndRemove(req.params.campusId)
        .then(campus => {
            if (!campus) {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.campusId
                });
            }
            res.send({ message: "Campus deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.campusId
                });
            }
            return res.status(500).send({
                message: "Could not delete campus with id " + req.params.campusId
            });
        });
};
