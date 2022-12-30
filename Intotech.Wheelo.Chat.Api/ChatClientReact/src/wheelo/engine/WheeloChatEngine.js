import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

export default class WheeloChatEngine {

    constructor(receiveMsgCall, connectedCallback, inviteToConv) {

        this.receiveMessageCall = receiveMsgCall;
        this.connectedCall = connectedCallback;
        this.inviteToConvCall = inviteToConv;
    }

    connection;
    messages = [];
    room;
    receiveMessageCall;
    connectedCall;
    inviteToConvCall;
    connectionId;

    serverUrl = "https://localhost:7082/wheeloChat";
    //serverUrl = "http://192.168.0.158:5130/wheeloChat";
    ReceiveMessageCallback = "ReceiveMessage"; // react callback
    joinRoomDelegate = "JoinWheeloRoom"; //method in c#
    sendMessageCallback = "SendMessage"; 
    connectUserDelegate = "ConnectUser"; //method in c#
    addUserCallback = "AddUser"; // react callback
    inviteToConversationCallback = "InviteToConversation"; // react callback
    requestConversationDelegate = "RequestConversation"; //method in c#
    approveChatDelegate = "ApproveChat"; // c#

    initialize = async () => {

        //this.room = room;

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl)
            .configureLogging(LogLevel.Information)
            .build();

        this.connection.on(this.ReceiveMessageCallback, (msgDto) => {
            
            this.receiveMessageCall(msgDto);
            //this.messages = [...this.messages, { user, message }];
        });

        this.connection.on(this.addUserCallback, (chatUser) => {

            console.log("Connected with data: ", chatUser);
            this.connectionId = chatUser.roomId;

            this.connectedCall(chatUser);
        });

        this.connection.on(this.inviteToConversationCallback, (dto) => {

            console.log("invite", dto);
            this.inviteToConvCall(dto);
        });

        this.connection.onclose(e => {
            this.connection = null;
        });

        try{

            await this.connection.start();
        }
        catch (e) {
            console.log(e);
        }
    }

    userConnect = async (accountId) => {
        console.log("accountId", accountId);
        try{
            await this.connection.invoke(this.connectUserDelegate, parseInt(accountId));
        }
        catch (e) {
            console.log(e);
        }
    }

    requestConversation = async (convDto) => {
        
        await this.connection.invoke(this.requestConversationDelegate, convDto);
    }

    sendMessage = async (authorAccountId, targetId, message) => {
        try {
          
          await this.connection.invoke(this.sendMessageCallback, 
            {  
                ChatParticipantId: targetId,
                ChatMessageAuthorId: authorAccountId,
                Message: message
            }); 

        } catch (e) {
          console.log(e);
        }
    }

    approveChat = async (firstParticipantId, secondParticipantId) => {

        await this.connection.invoke(this.approveChatDelegate, parseInt(firstParticipantId), parseInt(secondParticipantId));
    }
}