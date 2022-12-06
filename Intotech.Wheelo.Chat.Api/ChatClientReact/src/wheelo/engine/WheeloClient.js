import WheeloChatEngine from './WheeloChatEngine';

export default class WheeloClient {

    engineMap = [];

    addEngineToMap = (wheeloChatEngine, room) => {

        this.engineMap.push({"room": room, "engine": wheeloChatEngine});
    }

    getEngine = (room) => {
        var result;
        this.engineMap.forEach((element) => {
            
            if (element.room == room)
            {
                result = element.engine;
            }
        });

        return result;
    }

    connect = async(accountId, userName) => {

        var roomId = "accountId: " + accountId + ", accountName: " + userName + " random ending";

        var wheeloEngExists = this.getEngine(roomId);

        if (wheeloEngExists !== undefined)
        {
            await wheeloEngExists.userConnect(accountId, userName);
        }

        var wheeloChatEngine = new WheeloChatEngine(() => {});
        await wheeloChatEngine.initialize();

        this.addEngineToMap(wheeloChatEngine, roomId);

        await wheeloChatEngine.userConnect(accountId, userName);
    }

    requestConversation = async (invitingAccountId, invitingAccountName, invitedAccountId, invitedAccountName) => {

        var roomId = "accountId: " + invitedAccountId + ", accountName: " + invitedAccountName + " random ending";

        var wheeloEngExists = this.getEngine(roomId);

        if (wheeloEngExists !== undefined)
        {
            wheeloEngExists.requestConversation({invitingAccountId, invitingAccountName, invitedAccountId, invitedAccountName});
        }

        var wheeloChatEngine = new WheeloChatEngine(() => {});
        await wheeloChatEngine.initialize();

        this.addEngineToMap(wheeloChatEngine, roomId);

        wheeloChatEngine.requestConversation({invitingAccountId, invitingAccountName, invitedAccountId, invitedAccountName});
    }

    chat = async (room, user, message, recMagCall) => {

        var wheeloEngExists = this.getEngine(room);

        if (wheeloEngExists !== undefined)
        {
            wheeloEngExists.sendMessage(message, user);

            return wheeloEngExists;
        }

        var wheeloChatEngine = new WheeloChatEngine(recMagCall);

        await wheeloChatEngine.initialize();

        this.addEngineToMap(wheeloChatEngine, room);

//        await wheeloChatEngine.joinRoomClient(room);

        await wheeloChatEngine.sendMessage(message, user);

        return wheeloChatEngine;
    }
}