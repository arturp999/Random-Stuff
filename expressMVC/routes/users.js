var express = require('express');
var router = express.Router();
const Authentification = require('../Middleware/Authentification');


// Require controller modules
var UserController = require('../controller/UserController');

/// GET ROUTES ///
router.get('/', Authentification, function(req, res, next) {});

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
router.get('/profile', Authentification, UserController.profile );

//Delete button
router.post('/delete', Authentification, UserController.delete );

//Multer stuff
const multer = require('../controller/files');
const { route } = require('.');
router.post('/uploadfile', Authentification, multer.upload.single('myImage'), UserController.uploadSingle)
// router.post('/uploadmultiple', Authentification, multer.upload.array('myFiles', 10), UserController.uploadSingle)



module.exports = router;
