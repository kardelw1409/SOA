var express = require('express');
var router = express.Router();

var campus_controller = require('../controllers/campus');


router.get('/test', campus_controller.test);


router.post('/create', campus_controller.campus_create);

router.get('/:id', campus_controller.campus_details);

router.put('/:id/update', campus_controller.campus_update);

router.delete('/:id/delete', campus_controller.campus_delete);


module.exports = router;