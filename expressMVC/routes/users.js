var express = require('express');
var router = express.Router();
const Authentification = require('../Middleware/Authentification');


// Require controller modules
var UserController = require('../controller/UserController');
const { flash } = require('express-flash-message');

/// GET ROUTES ///
router.get('/', Authentification, function(req, res, next) {
  console.log("here")
});

//LOGIN

router.get('/login', function(req, res, next) {
  res.render('login.ejs', { message: req.flash('message') });
});
router.post('/login', UserController.login);

//Register
router.get('/register', function(req, res, next) {
  res.render('register.ejs', { message: req.flash('message') });
});
router.post('/register', UserController.register);


router.get('/logout', UserController.logout);

module.exports = router;
