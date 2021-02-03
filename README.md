# Collects requests and stores they're responses

# Q&A:
1. The part of "fetch multiple request objects from the queue" is confusing, did it mean: fetch multiple responses from the queue? THE queue is assumed to be the only mentioned queue, which is the responses queue.
2. What initiates the request generation? The request executor calls it on demand.
3. What initiates the request executor? Client demand by API.
