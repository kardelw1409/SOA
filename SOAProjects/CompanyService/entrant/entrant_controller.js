const Entrant = require('./entrant_model');
// Создание и сохранение нового абитуриента
module.exports.create = (req, res) => {
    // Проверка
    if (!req.body.medal) {
        return res.status(400).send({
            message: "Entrant content can not be empty1"
        });
    }
    if (!req.body.total_score) {
        return res.status(400).send({
            message: "Entrant content can not be empty2"
        });
    }
  /*  if (!req.body.is_entranted) {
      return res.status(400).send({
      message: "Entrant content can not be empty3"
        });
    }
  */
    if (!req.body.entrant_year) {
        return res.status(400).send({
            message: "Entrant content can not be empty4"
        });
    }
    // Создание абитуриента
    const entrant = new Entrant({
        _id: req.body.id,
        medal: req.body.medal,
        total_score: req.body.total_score,
        is_entranted: req.body.is_entranted,
        entrant_year: req.body.entrant_year,
        _profile_id: Profile.findById(req.params._profile_id)
    });

    // Сохранение абитуриента а бд
    entrant.save()
        .then(data => {
            res.send(data);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Ошибка создания"
            });
        });
};

// Нахождение всех абитуриентов и вывод
module.exports.findAll = (req, res) => {
    Entrant.find()
        .then(entrantes => {
            res.send(entrantes);
        }).catch(err => {
            res.status(500).send({
                message: err.message || "Ошибка"
            });
        });
};

// Нахожддение одного абитуриента по ID
module.exports.findOne = (req, res) => {
    Entrant.findById(req.params.entrantId)
        .then(entrant => {
            if (!entrant) {
                return res.status(404).send({
                    message: "Нет ID c номером" + req.params.entrantId
                });
            }
            res.send(entrant);
        }).catch(err => {
            if (err.kind === 'ObjectId') {
                return res.status(404).send({
                    message: "Нет ID c номером " + req.params.entrantId
                });
            }
            return res.status(500).send({
                message: "Ошибка с ID" + req.params.entrantId
            });
        });
};

// Update a note identified by the noteId in the request
module.exports.update = (req, res) => {
    // Проверка
    if (!req.body.medal) {
        return res.status(400).send({
            message: "Error"
        });
    }
    if (!req.body.total_score) {
        return res.status(400).send({
            message: "Error"
        });
    }
    if (!req.body.is_entranted) {
        return res.status(400).send({
            message: "Error"
        });
    }
    if (!req.body.entrant_year) {
        return res.status(400).send({
            message: "Error"
        });
    }
    // Нахождение и обновление абитуриента посредством запроса
    Entrant.findByIdAndUpdate(req.params.entrantId, {
        medal: req.body.medal,
        total_score: req.body.total_score,
        is_entranted: req.body.is_entranted,
        entrant_year: req.body.entrant_year
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

// Удаление Абитуриента по ID запроса
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
