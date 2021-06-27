var db = require("../models");
const generateToken = require("../Middleware/AuthTokenGenerator");


exports.register = function (req, res, next) {
  var email = req.body.email;
  var password = req.body.password;
  var name = req.body.name;
  console.log(req.body)
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
      generateToken(res, email, password); //generates token after register
      res.redirect("/");
    }
  });
};

exports.login = (req, res) => {
  var email = req.body.email;
  var password = req.body.password;

  try {
    User.findOne({
      where: {
        email: email,
        password: password,
      },
    }).then((result) => {
      if (result) {
        generateToken(res, email, password); //generates token after login
        //res.redirect("/");
      } else {
        console.log("something wrong");
      }
    });
  } catch (error) {
    return res.status(500).json(err.toString());
  }
};
