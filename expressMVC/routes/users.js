var express = require('express');
var router = express.Router();
const Authentification = require('../Middleware/Authentification');


// Require controller modules
var UserController = require('../controller/UserController');

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

//Logout
router.get('/logout', UserController.logout);

//Profile Page
router.get('/profile', Authentification,UserController.profile );

//Multer stuff
const multer = require('../controller/files');
router.post('/uploadfile', Authentification, multer.upload.single('myImage'), UserController.uploadSingle)

module.exports = router;
