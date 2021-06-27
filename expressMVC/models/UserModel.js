module.exports = (sequelize, DataTypes) => {
  User = sequelize.define('user',
    {
      name: DataTypes.STRING,
      email: DataTypes.STRING,
      password: DataTypes.STRING,
    }
  );
  return User;
};
