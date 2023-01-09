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

    serverUrl = "http://localhost:5130/wheeloChat";
    //serverUrl = "http://4.231.89.226:5130/wheeloChat";
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

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl, {
                accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJ6YXBhcnRAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJhcnRlayBaYXBhcnQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjczNDU3NjUxLCJpc3MiOiJodHRwOi8vaW50b3RlY2guY29tLnBsIiwiYXVkIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCJ9.wLubK-bSPgnfgVwMcHgq8BHn7WKSUlqblToRLUreIZc"
              })
            .configureLogging(LogLevel.Error)
            .build();

        console.log("Connection: ", this.connection);

        this.connection.on(this.ReceiveMessageCallback, (msgDto) => {
            
            this.receiveMessageCall(msgDto);
            //this.messages = [...this.messages, { user, message }];
        });

        this.connection.on("PocResponse", (dto) => {

            console.log("PocResponse", dto);
            
        });

        this.connection.on(this.addUserCallback, (chatUser) => {

            console.log("Connected with data: ", chatUser);
        
            this.connectedCall(chatUser);
        });

        this.connection.on(this.inviteToConversationCallback, (dto) => {

            console.log("invite", dto);
            this.inviteToConvCall(dto);
        });

        this.connection.onclose(e => {
            this.connection = null;
        });
        //this.connection.qs = { "token" : "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJ6YXBhcnRAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJhcnRlayBaYXBhcnQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTY3MzQ1MTI0OCwiaXNzIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCIsImF1ZCI6Imh0dHA6Ly9pbnRvdGVjaC5jb20ucGwifQ.VuURd6KCk9sasy7T1Gku1FpjVCNTqWRS43wC2swtEzE" };
//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJ6YXBhcnRAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJhcnRlayBaYXBhcnQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTY3MzQ1MTI0OCwiaXNzIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCIsImF1ZCI6Imh0dHA6Ly9pbnRvdGVjaC5jb20ucGwifQ.VuURd6KCk9sasy7T1Gku1FpjVCNTqWRS43wC2swtEzE
        await this.connection.start();
    }

    userConnect = async (accountId) => {

        console.log("accountId", accountId);
        try{
            await this.connection.invoke(this.connectUserDelegate, parseInt(accountId), "");
        }
        catch (e) {
            console.log(e);
        }
    }

    requestConversation = async (convDto) => {
        
        await this.connection.invoke(this.requestConversationDelegate, convDto);
    }

    ProofOfConcept = async(userId) => {

        await this.connection.invoke("ProofOfConcept", userId);
    }

    sendMessage = async (authorAccountId, targetId, message) => {
        try {
          
          await this.connection.invoke(this.sendMessageCallback, 
            {
             SenderID: authorAccountId,
             Text: message,
             ID: targetId,
             CreatedAt: "2023-01-07",
             AuthorFirstName: "Bartek",
             AuthorLastName: "Zapart"
            }); 

        } catch (e) {
          console.log(e);
        }
    }

    approveChat = async (participantId, roomId) => {

        await this.connection.invoke(this.approveChatDelegate, parseInt(participantId), parseInt(roomId));
    }
}