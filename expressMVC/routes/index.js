var express = require('express');
var router = express.Router();
const Authentification = require('../Middleware/Authentification');


/* GET home page. */
router.get('/', function(req, res, next) {
  var isLoggedin;
  if (req.cookies.token) {
    isLoggedin = true
  } else {
    isLoggedin = false
  }
  res.render('index', { message: req.flash('message'), isLoggedin} );
});


module.exports = router;
