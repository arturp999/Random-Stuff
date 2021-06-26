const jwt = require("jsonwebtoken");
const dotenv = require("dotenv");
// get config vars
dotenv.config();

//global.crypto = require('crypto')
// var token = crypto.randomBytes(64).toString('hex');
// console.log(token)

function generateAccessToken(username) {
  return jwt.sign(username, process.env.TOKEN_SECRET, { expiresIn: "1800s" });
}

var Authentification = function (req, res, next) {
  console.log("LOGGED");

  next();
};

module.exports = Authentification;
