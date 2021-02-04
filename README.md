# Abtract

Collects requests and stores they're responses

# Get started

1. Make sure docker and docker-compose are installed
2. clone project
3. `docker-compose up`
4. When all services are idle, fire POST request to enquqe request objects:

`POST /MultiRequestProcess HTTP/1.1`

`Host: <host>:<post>`

# Flow (PUML)

![Diagram](flow.png)

```puml
@startuml

actor client as "Client"
participant req_exe as "Request Executor"
participant req_gen as "Request Generator"
collections pub_api as "Public APIs"
participant res_con as "Response Comsumer"
database res_db as "Response Collection"
queue res_q as "Response Queue"

client -> req_exe: Enqueue n request objects
req_exe -> req_gen: Generate n request objects
req_gen --> req_exe: Request n objects (with priority)

loop n times by priority
    req_exe -> pub_api: Execute request
    pub_api --> req_exe: Response
    req_exe -> res_q: New response
end

loop every x seconds
    res_con -> res_q: Pull n responses
    res_q --> res_con: n responses
    res_con -> res_db: Store responses
end

@enduml
```

# Q&A:
1. The part of "fetch multiple request objects from the queue" is confusing, did it mean: fetch multiple responses from the queue? THE queue is assumed to be the only mentioned queue, which is the responses queue.
2. What initiates the request generation? The request executor calls it on demand.
3. What initiates the request executor? Client demand by API.
