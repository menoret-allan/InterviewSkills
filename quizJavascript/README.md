language: node_js
node_js:
  - "5"
before_install:
  - "npm install -g jasmine-node && npm upgrade jasmine-node"
script:
  - "jasmine-node spec --verbose"
