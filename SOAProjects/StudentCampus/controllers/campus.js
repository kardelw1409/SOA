var Campus = require('../models/campus');

exports.test = function (req, res) {
    res.send('Greetings from Campus controller!');
};

exports.campus_create = function (req, res) {
    var campus = new Campus(
        {
            id: req.body.id,
            adress: req.body.adress
        }
    );

    campus.save(function (err) {
        if (err) {
            return next(err);
        }
        res.send('Campus Created successfully')
    })
};

exports.campus_details = function (req, res) {
    Campus.findById(req.params.id, function (err, campus) {
        if (err) return next(err);
        res.send(campus);
    })
};

exports.campus_update = function (req, res) {
    Campus.findByIdAndUpdate(req.params.id, { $set: req.body }, function (err, campus) {
        if (err) return next(err);
        res.send('Campus udpated.');
    });
};

exports.Campus_delete = function (req, res) {
    Campus.findByIdAndRemove(req.params.id, function (err) {
        if (err) return next(err);
        res.send('Deleted successfully!');
    })
};