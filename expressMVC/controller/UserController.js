var db = require("../models");
const generateToken = require("../Middleware/AuthTokenGenerator");

exports.register = function (req, res, next) {
  var email = req.body.email;
  var password = req.body.password;
  var name = req.body.name;
  var pattern = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
  if (pattern.test(email)) {
    User.findOne({
      where: {
        email: email,
      },
    })
      .then((result) => {
        if (result == null) {
          if (password.length < 6) {
            req.flash(
              "message",
              "Your password is too short you need at least 6 characters!"
            );
            res.redirect("/users/register");
          } else if (password == email) {
            req.flash(
              "message",
              "Your email cant be the same has your password!"
            );
            res.redirect("/users/register");
          } else if (name == "") {
            req.flash("message", "Your name cant be empty");
            res.redirect("/users/register");
          } else {
            User.create({ name: name, email: email, password: password }).then(
              (user) => {
                generateToken(res, email, password); //generates token after login
                res.redirect("/users/profile");
              }
            );
          }
        } else {
          req.flash("message", "That e-mail is already taken.");
          res.redirect("/users/register");
        }
      })
      .catch(function (err) {
        req.flash("message", err);
        res.redirect("/users/register");
      });
  } else {
    req.flash("message", "That format is not valid");
    res.redirect("/users/register");
  }
};

exports.login = (req, res) => {
  var email = req.body.email;
  var password = req.body.password;

  if (email == "" || email == undefined || password == "" || password == undefined) {
    req.flash("message", "You need to fill the Email/Password");
    res.redirect("/users/login");
  } else {
    User.findOne({
      where: {
        email: email,
      },
    }).then((result) => {
      if (password == result.password) {
        generateToken(res, email, password); //generates token after login
        req.flash("message", "Successfully logged in");
        res.redirect("/");
      } else {
        req.flash("message", "Wrong password");
        res.redirect("/users/login");
      }
    });
  }
};

exports.logout = function (req, res) {
  res.clearCookie("token");
  req.flash("message", "You have logged out");
  res.redirect("/");
};
