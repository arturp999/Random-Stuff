const dotenv = require('dotenv');
const jwt = require('jsonwebtoken');

dotenv.config();
const Authentification = async (req, res, next) => {
  const token = req.cookies.token || '';
  try {
    if (!token) {
      
      //return res.status(401).json('You need to Login')
      res.redirect("/login");
    }
    const decrypt = await jwt.verify(token, process.env.TOKEN_SECRET);
    req.user = {
      email: decrypt.email,
      password: decrypt.password,
    };
    next();
  } catch (err) {
    res.redirect("/login");
    //return res.status(500).json(err.toString());
  }
};

module.exports = Authentification;