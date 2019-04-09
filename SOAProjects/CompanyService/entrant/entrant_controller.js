//Импортирование
const Entrant = require('./entrant_model');
// Создание и сохранение нового абитуриента
module.exports.create = (req, res) => {
    // Проверка
    if (!req.body.number) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    if (!req.body.adress) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    // Create a Campus
    const entrant = new Entrant({
        number: req.body.number,
        adress: req.body.adress
    });

    // Save Campus in the database
    entrant.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while creating the Campus."
            });
        });
};

// Retrieve and return all campuses from the database.
module.exports.findAll = (req, res) => {
    Entrant.find()
        .then(entrantes => {
            res.send(entrantes);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving campuses."
            });
        });
};

// Find a single campus with a campusId
module.exports.findOne = (req, res) => {
    Entrant.findById(req.params.entrantId)
        .then(entrant => {
            if (!entrant) {
                return res.status(404).send({
                    message: "Entrant not found with id " + req.params.entrantId
                });
            }
            res.send(entrant);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Entrant not found with id " + req.params.entrantId
                });
            }
            return res.status(500).send({
                message: "Error retrieving campus with id " + req.params.entrantId
            });
        });
};

// Update a note identified by the noteId in the request
module.exports.update = (req, res) => {
    // Validate Request
    if (!req.body.number) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    if (!req.body.adress) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    // Find campus and update it with the request body
    Entrant.findByIdAndUpdate(req.params.entrantId, {
        number: req.body.number,
        adress: req.body.adress
    }, { new: true })
        .then(entrant => {
            if (!entrant) {
                return res.status(404).send({
                    message: "Entrant not found with id " + req.params.entrantId
                });
            }
            res.send(entrant);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Entrant not found with id " + req.params.entrantId
                });
            }
            return res.status(500).send({
                message: "Error updating entrant with id " + req.params.EntrantId
            });
        });
};

// Delete a campus with the specified campusId in the request
module.exports.delete = (req, res) => {
    Entrant.findByIdAndRemove(req.params.entrantId)
        .then(entrant => {
            if (!entrant) {
                return res.status(404).send({
                    message: "Entrant not found with id " + req.params.entrantId
                });
            }
            res.send({ message: "Entrant deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Entrant not found with id " + req.params.entrantId
                });
            }
            return res.status(500).send({
                message: "Could not delete entrant with id " + req.params.entrantId
            });
        });
};
