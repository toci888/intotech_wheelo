import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

export default class WheeloChatEngine {

    constructor(receiveMsgCall) {

        this.receiveMessageCall = receiveMsgCall;
    }

    connection;
    messages = [];
    room;
    receiveMessageCall;
    connectionId;

    //serverUrl = "https://localhost:7082/wheeloChat";
    serverUrl = "http://192.168.0.158:5130/wheeloChat";
    ReceiveMessageCallback = "ReceiveMessage"; // react callback
    joinRoomDelegate = "JoinWheeloRoom"; //method in c#
    sendMessageCallback = "SendMessage";
    connectUserDelegate = "ConnectUser"; //method in c#
    addUserCallback = "AddUser"; // react callback
    inviteToConversationCallback = "InviteToConversation"; // react callback
    requestConversationDelegate = "RequestConversation"; //method in c#

    initialize = async () => {

        //this.room = room;

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl)
            .configureLogging(LogLevel.Information)
            .build();

        this.connection.on(this.ReceiveMessageCallback, (msgDto) => {
            
            this.receiveMessageCall(msgDto.user.userName, msgDto.message);
            //this.messages = [...this.messages, { user, message }];
        });

        this.connection.on(this.addUserCallback, (userId) => {

            console.log("Connected with userId: ", userId);
            this.connectionId = userId;
        });

        this.connection.on(this.inviteToConversationCallback, (invitingAccountId, invitingUserName) => {

            console.log("invite", invitingAccountId, invitingUserName);
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

    sendMessage = async (message, user) => {
        try {
          
          await this.connection.invoke(this.sendMessageCallback, 
            {  user: 
                { UserId: 1, UserName: user },
                Message: message,
                RoomName: this.room
            }); 

        } catch (e) {
          console.log(e);
        }
      }
}