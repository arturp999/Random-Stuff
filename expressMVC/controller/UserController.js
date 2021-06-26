var db = require("../models");

exports.register = function (req, res, next) {
  var email = req.body.email;
  var password = req.body.password;
  var name = req.body.name;
  User.findOne({
    where: {
      email: email,
    },
  }).then((result) => {
    if (result) {
      console.log("User already exists");
      res.redirect("/login");
    } else {
      User.create({
        name: name,
        email: email,
        password: password,
      });
    }
  });
};

exports.login = function (req, res, next) {
  var email = req.body.email;
  var password = req.body.password;
  User.findOne({
    where: {
      email: email,
      password: password,
    },
  }).then((result) => {
    if (result) {
      res.redirect("/");
    } else {
      console.log("something wrong");
    }
  });
};
