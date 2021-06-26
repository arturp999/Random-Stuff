var User = require('../models/User')

exports.login =  function(req, res, next) {
    var email = req.body.email
    var password = req.body.password
    var name = req.body.name
    console.log('im here login')
  };


exports.register =  function(req, res, next) {
    var email = req.body.email
    var password = req.body.password
    var name = req.body.name
    console.log('im here register')
  };

