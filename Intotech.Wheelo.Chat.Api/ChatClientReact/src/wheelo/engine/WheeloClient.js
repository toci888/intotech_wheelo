import WheeloChatEngine from './WheeloChatEngine';

export default class WheeloClient {

    constructor(receiveMsgCall, connectedCallback, inviteToConv) {

        this.receiveMessageCall = receiveMsgCall;
        this.connectedCall = connectedCallback;
        this.inviteToConvCall = inviteToConv;

        this.wheeloChatEngine = new WheeloChatEngine(this.receiveMessageCall, this.connectedCall, this.inviteToConvCall);
        this.wheeloChatEngine.initialize();
    }

    receiveMessageCall;
    connectedCall;
    inviteToConvCall;
    wheeloChatEngine;

    /*engineMap = [];

    addEngineToMap = (wheeloChatEngine, room) => {

        this.engineMap.push({"room": room, "engine": wheeloChatEngine});
    }

    getEngine = async (room) => {

        var result;

        this.engineMap.forEach((element) => {
            
            if (element.room == room)
            {
                result = element.engine;
            }
        });

        if (result === undefined)
        {
            result = new WheeloChatEngine(this.receiveMessageCall, this.connectedCall, this.inviteToConvCall);

            await result.initialize();
            
            this.addEngineToMap(result, room);
        }

        return result;
    }

    useWheeloChatEngine = () => {


    }*/

    connect = async(accountId) => {

        await this.wheeloChatEngine.userConnect(accountId);
    }

    requestConversation = async (invitingAccountId, invitingUserName, invitedAccountIds) => {

        var invAccountIds = new Array();

        var json = {
            InvitedAccountIds: invitedAccountIds,
            InvitingAccountId: parseInt(invitingAccountId),
            InvitingUserName: invitingUserName
        }

        await this.wheeloChatEngine.requestConversation(json);
    }

    chat = async (authorId, roomId, message) => {

        authorId = parseInt(authorId);
        roomId = parseInt(roomId);

        await this.wheeloChatEngine.sendMessage(authorId, roomId, message);
    }

    approveChat = async (participantId, roomId) => {

        await this.wheeloChatEngine.approveChat(participantId, roomId);
    }
}