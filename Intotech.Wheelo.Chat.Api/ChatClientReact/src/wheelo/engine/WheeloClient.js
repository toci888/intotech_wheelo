import WheeloChatEngine from './WheeloChatEngine';


export default class WheeloClient {

    engineMap = [];

    addEngineToMap = (wheeloChatEngine, room) => {

        this.engineMap.push({"room": room, "engine": wheeloChatEngine});
    }

    getEngine = (room) => {
        var result;
        this.engineMap.forEach((element) => {
            console.log("element", element);
            if (element.room == room)
            {
                result = element.engine;
            }
        });

        return result;
    }

    chat = async (room, user, message, recMagCall) => {

        var wheeloEngExists = this.getEngine(room);

        if (wheeloEngExists !== undefined)
        {
            console.log("zjebane !", wheeloEngExists);

            wheeloEngExists.sendMessage(message, user);

            return wheeloEngExists;
        }

        var wheeloChatEngine = new WheeloChatEngine(recMagCall);

        this.addEngineToMap(wheeloChatEngine, room);

        await wheeloChatEngine.joinRoomClient(room);

        await wheeloChatEngine.sendMessage(message, user);

        return wheeloChatEngine;
    }
}