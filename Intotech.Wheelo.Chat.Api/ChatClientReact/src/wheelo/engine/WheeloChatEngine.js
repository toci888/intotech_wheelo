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

    //serverUrl = "http://localhost:5130/wheeloChat";
    serverUrl = "http://4.231.89.226:5130/wheeloChat";
    //serverUrl = "http://192.168.0.158:5130/wheeloChat"; 
    ReceiveMessageCallback = "getMessage"; // react callback
    joinRoomDelegate = "JoinWheeloRoom"; //method in c#
    sendMessageCallback = "SendMessage"; 
    connectUserDelegate = "ConnectUser"; //method in c#
    addUserCallback = "session"; // react callback
    inviteToConversationCallback = "InviteToConversation"; // react callback
    requestConversationDelegate = "CreateRoom"; //method in c#
    approveChatDelegate = "ApproveChat"; // c#

    initialize = async () => {

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl, {
                accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJhcnRla0BnZy5wbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJTdGVmYW5pYSBEemlld3Vsc2tpIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTY3MzYzMTQ0OSwiaXNzIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCIsImF1ZCI6Imh0dHA6Ly9pbnRvdGVjaC5jb20ucGwifQ.co-CSfDlsdq4EHHtskho6Y7ixdBC15ItFxxcZIbwbfA"
              })
            .configureLogging(LogLevel.Error)
            .build();

        console.log("Connection: ", this.connection);

        this.connection.on(this.ReceiveMessageCallback, (msgDto) => {
            console.log("getMessage", msgDto);
            this.receiveMessageCall(msgDto);
            //this.messages = [...this.messages, { user, message }];
        });

        this.connection.on("PocResponse", (dto) => {

            console.log("PocResponse", dto);
            
        });

        this.connection.on("RoomEstablished", (dto) => {

            console.log("RoomEstablished, invoking JoinRoom", dto.room, dto.room.idRoom);

            this.connection.invoke("JoinRoom", parseInt(dto.room.idRoom));
            
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
        
        await this.connection.start();
    }

    userConnect = async (email) => {

        console.log("accountId", email);
        try{
            await this.connection.invoke(this.connectUserDelegate, email);
        }
        catch (e) {
            console.log(e);
        }
    }

    requestConversation = async () => {
        
        await this.connection.invoke(this.requestConversationDelegate, "bzapart@gmail.com", new Array("warriorr@poczta.fm", "1111111191kapi@gmail.com", "bartek@gg.pl"));
    }

    ProofOfConcept = async(userId) => {

        await this.connection.invoke("ProofOfConcept", userId);
    }

    sendMessage = async (authorAccountId, targetId, message) => {
        try {
          console.log("dafaq", authorAccountId);
          await this.connection.invoke(this.sendMessageCallback, 
            {
             SenderID: authorAccountId,
             Text: message,
             ID: targetId,
             CreatedAt: "2023-01-07",
             AuthorFirstName: "Bartek",
             AuthorLastName: "Zapart",
             RoomID: targetId
            }); 
/*
        public string SenderID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ID { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int RoomID { get; set; }*/
        } catch (e) {
          console.log(e);
        }
    }

    approveChat = async (participantId, roomId) => {

        await this.connection.invoke(this.approveChatDelegate, parseInt(participantId), parseInt(roomId));
    }
}