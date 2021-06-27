var express = require('express');
var router = express.Router();
const Authentification = require('../Middleware/Authentification');


// Require controller modules
var UserController = require('../controller/UserController');
const { flash } = require('express-flash-message');

/// GET ROUTES ///
router.get('/', Authentification, function(req, res, next) {
  console.log("HEREEEEEEEEEE");
});

//LOGIN
router.get('/login', function(req, res, next) {
  res.render('login.ejs', { message: req.flash('loginMessage') });
});
router.post('/login', UserController.login);

//Posts the new user to DB
router.post('/register', UserController.register);
//User.create({ name: 'admin', email: 'admin@admin.com', password: 'admin' });

module.exports = router;
