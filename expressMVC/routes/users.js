var express = require('express');
var router = express.Router();


// Require controller modules
var UserController = require('../controller/UserController');

/// GET ROUTES ///
router.get('/', function(req, res, next) {
  res.send('respond with a resource');
});

//Posts the new user to DB
router.post('/register', UserController.register);
//User.create({ name: 'admin', email: 'admin@admin.com', password: 'admin' });

module.exports = router;
