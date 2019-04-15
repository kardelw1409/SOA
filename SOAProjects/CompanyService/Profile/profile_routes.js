module.exports = (app) => {
    //����������� ����������
    const profiles = require('./profile_controller');//

    // �������� �������
    app.post('/Profile', profiles.create);

    // ���������� ����
    app.get('/Profile', profiles.findAll);

    // ���������� �� ID
    app.get('/Profile/:profilesId', profiles.findOne);

    // ���������� �� ID
    app.put('/Profile/:profilesId', profiles.update);

    // �������� ������� �� ID
    app.delete('/Profile/:profilesId', profiles.delete);
}