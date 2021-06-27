const dotenv = require("dotenv");
const jwt = require("jsonwebtoken");

dotenv.config();
const Authentification = async (req, res, next) => {
  const token = req.cookies.token || "";
  try {
    if (!token) {
      req.flash("message", "You need to be  logged in to visit that page");
      res.redirect("/users/login");
    } else {
      const decrypt = await jwt.verify(token, process.env.TOKEN_SECRET);
      req.user = {
        email: decrypt.email,
        password: decrypt.password,
      };
      next();
    }
  } catch (err) {
    res.redirect("/users/login");
    //return res.status(500).json(err.toString());
  }
};

module.exports = Authentification;
