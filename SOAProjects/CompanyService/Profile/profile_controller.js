//require('module-alias/register');
const Profile = require('./profile_model');
//import Campus from "./campus.model";
// Create and Save a new Campus
module.exports.create = (req, res) => {
    // Validate request
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
    const entrant = new Profile({
        number: req.body.number,
        adress: req.body.adress
    });

    // Save Campus in the database
    profile.save()
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
    Profile.find()
        .then(profiles => {
            res.send(profiles);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving campuses."
            });
        });
};

// Find a single campus with a campusId
module.exports.findOne = (req, res) => {
    Profile.findById(req.params.profileId)
        .then(profile => {
            if (!profile) {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.profileId
                });
            }
            res.send(profile);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.profileId
                });
            }
            return res.status(500).send({
                message: "Error retrieving campus with id " + req.params.profileId
            });
        });
};

// Update a note identified by the noteId in the request
module.exports.update = (req, res) => {
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
    Profile.findByIdAndUpdate(req.params.profileId, {
        number: req.body.number,
        adress: req.body.adress
    }, { new: true })
        .then(profile => {
            if (!profile) {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.profileId
                });
            }
            res.send(profile);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.profileId
                });
            }
            return res.status(500).send({
                message: "Error updating campus with id " + req.params.profileId
            });
        });
};

// Delete a campus with the specified campusId in the request
module.exports.delete = (req, res) => {
    Profile.findByIdAndRemove(req.params.profileId)
        .then(profile => {
            if (!profile) {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.profileId
                });
            }
            res.send({ message: "Campus deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Campus not found with id " + req.params.profileId
                });
            }
            return res.status(500).send({
                message: "Could not delete campus with id " + req.params.profileId
            });
        });
};
