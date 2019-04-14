module.exports = (app) => {
    //подключение контролера
    const profiles = require('./profile_controller');//

    // Создание профиля
    app.post('/Profile', profiles.create);

    // Нахождение всех
    app.get('/Profile', profiles.findAll);

    // Нахождение по ID
    app.get('/Profile/:profilesId', profiles.findOne);

    // Обновление по ID
    app.put('/Profile/:profilesId', profiles.update);

    // Удаление профиля по ID
    app.delete('/Profile/:profilesId', profiles.delete);
}