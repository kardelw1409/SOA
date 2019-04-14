const Profile = require('./profile_model');
// �������� � ���������� Profile
module.exports.create = (req, res) => {
    // ��������
    if (!req.body.first_name) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    if (!req.body.last_name) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    if (!req.body.patronymic) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    if (!req.body.birthday) {
        return res.status(400).send({
            message: "Entrant content can not be empty"
        });
    }
    // �������� ������� ��������
    const profile = new Profile({
        first_name: req.body.first_name,
        last_name: req.body.last_name,
        patronymic: req.body.patronymic,
        birthday: req.body.birthday
    });

    // ���������� � ��
    profile.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while creating the Profile."
            });
        });
};

// ���������� � ��������� � ��
module.exports.findAll = (req, res) => {
    Profile.find()
        .then(profiles => {
            res.send(profiles);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Some error occurred while retrieving profiles."
            });
        });
};

// ���������� ������ �� ID 
module.exports.findOne = (req, res) => {
    Profile.findById(req.params.profileId)
        .then(profile => {
            if (!profile) {
                return res.status(404).send({
                    message: "Profile not found with id " + req.params.profileId
                });
            }
            res.send(profile);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Profile not found with id " + req.params.profileId
                });
            }
            return res.status(500).send({
                message: "Error retrieving profile with id " + req.params.profileId
            });
        });
};

// Update a note identified by the noteId in the request
module.exports.update = (req, res) => {
    // ��������
    if (!req.body.first_name) {
        return res.status(400).send({
            message: "Profile content can not be empty"
        });
    }
    if (!req.body.last_name) {
        return res.status(400).send({
            message: "Profile content can not be empty"
        });
    }
    if (!req.body.patronymic) {
        return res.status(400).send({
            message: "Profile content can not be empty"
        });
    }
    if (!req.body.birthday) {
        return res.status(400).send({
            message: "Profile content can not be empty"
        });
    }
    // ���������� � ���������� ����������� ����������� �������
    Profile.findByIdAndUpdate(req.params.profileId, {
        first_name: req.body.first_name,
        last_name: req.body.last_name,
        patronymic: req.body.patronymic,
        birthday: req.body.birthday
    }, { new: true })
        .then(profile => {
            if (!profile) {
                return res.status(404).send({
                    message: "Profile not found with id " + req.params.profileId
                });
            }
            res.send(profile);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Profile not found with id " + req.params.profileId
                });
            }
            return res.status(500).send({
                message: "Error updating profile with id " + req.params.profileId
            });
        });
};

// ������� ������� �� ID �������
module.exports.delete = (req, res) => {
    Profile.findByIdAndRemove(req.params.profileId)
        .then(profile => {
            if (!profile) {
                return res.status(404).send({
                    message: "Profile not found with id " + req.params.profileId
                });
            }
            res.send({ message: "Profile deleted successfully!" });
        }).catch(err => {
            if (err.kind === 'ObjectId' || err.name === 'NotFound') {
                return res.status(404).send({
                    message: "Profile not found with id " + req.params.profileId
                });
            }
            return res.status(500).send({
                message: "Could not delete profile with id " + req.params.profileId
            });
        });
};
