import WheeloChatEngine from './WheeloChatEngine';

export default class WheeloClient {

    constructor(receiveMsgCall, connectedCallback, inviteToConv) {

        this.receiveMessageCall = receiveMsgCall;
        this.connectedCall = connectedCallback;
        this.inviteToConvCall = inviteToConv;
    }

    receiveMessageCall;
    connectedCall;
    inviteToConvCall;

    engineMap = [];

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


    }

    connect = async(accountId) => {

        var roomId = "accountId: " + accountId;

        var wheeloEngExists = await this.getEngine(roomId);

        await wheeloEngExists.userConnect(accountId);
    }

    requestConversation = async (invitingAccountId, invitedAccountId) => {

        var roomId = "accountId: " + invitedAccountId + ", accountId: " + invitingAccountId;

        var json = {
            InvitedAccountId: parseInt(invitedAccountId),
            InvitedUserName: "",
            InvitingAccountId: parseInt(invitingAccountId),
            InvitingUserName: "",
            RoomId: roomId
        }

        var wheeloEngExists = await this.getEngine(roomId);

        await wheeloEngExists.requestConversation(json);
    }

    chat = async (authorId, recipientId, message) => {

        authorId = parseInt(authorId);
        recipientId = parseInt(recipientId);

        var roomId;
        
        if (authorId > recipientId)
        {
            roomId = "accountId: " + recipientId + ", accountId: " + authorId;
        }
        else
        {
            roomId = "accountId: " + authorId + ", accountId: " + recipientId;
        }

        var wheeloEngExists = await this.getEngine(roomId);

        wheeloEngExists.sendMessage(authorId, recipientId, message);

        return wheeloEngExists;
    }
}