## 13 - Quais são as principais diferenças entre segurança de transporte e segurança no destino em 
microsserviços?

A segurança de transporte se refere à proteção dos dados durante a transmissão entre os microsserviços. 
Isso inclui a criptografia dos dados em trânsito, autenticação e autorização entre os serviços. O objetivo é garantir que os dados sejam 
protegidos contra interceptação, alteração ou acesso não autorizado durante a transmissão, alguns desses modelos posem ser:
Criptografia de dados em trânsito (TLS, SSL, etc.)
Autenticação e autorização entre serviços (OAuth, JWT, etc.)

A segurança no destino se refere à proteção dos dados quando eles alcançam o destino, ou seja, quando os 
dados são armazenados ou processados dentro de um microsserviço. Isso inclui a proteção contra acesso não autorizado, 
alteração ou perda 
de dados.
Autenticação e autorização para acesso a recursos e dados
Controle de acesso baseado em funções (RBAC)
Proteção contra ataques de injeção de SQL e cross-site scripting (XSS)

## 14 - Quais técnicas de segurança de rede podem ser aplicadas em um ambiente de microsserviços?

Autenticação de Usuários e Controle de Acesso
Manter a segurança de nossos endpoints e acesso a conteúdo não autorizado trata-se da base para qualquer
ambiente dito seguro. Neste contexto, autenticação e controle de acesso (autorização) representam partes 
críticas para um plano sólido envolvendo implantação de segurança bem sucedida.
Usando Tokens: Acesso e Identidade
Firewall de Aplicação (WAF)
Proteção contra ataques de injeção de SQL e cross-site scripting (XSS), os firewall fazem filtragem de tráfego de entrada e saída 
para evitar ataques mal-intencionados.
Anonimização de dados
A anonimização é uma técnica de processamento de dados que remove ou modifica informações que possam identificar uma pessoa. Essa 
técnica resulta em dados anonimizados, que não podem ser associados a nenhum indivíduo específico. 

## 15 - O que é "Defense in Depth" e por que é importante em microsserviços?

Defense in Depth
Serviços contendo dados sensíveis precisam de camadas adicionais de defesa, evitando que invasores apropriem-se de serviços adicionais 
ao elemento comprometido. Com o objetivo de proteger o núcleo destes serviços, práticas como a Defesa em profundidade (Defense in Depth) 
sugerem uma estratégia composta por diversos níveis de segurança, exigindo múltiplas camadas de proteção desde físicas / rede até 
aplicação / código.
Desta forma Defense in Depth é uma abordagem de segurança que envolve a implementação de múltiplas camadas de segurança para proteger 
um sistema ou aplicação contra ataques e vulnerabilidades. Essa abordagem é especialmente importante em microsserviços, onde a 
complexidade e a distribuição dos sistemas aumentam o risco de ataques e vulnerabilidades.

## 16 - Quais são as vantagens de automatizar o processo de deploy de microsserviços?

O deploy automatizado é uma ferramenta que garante mais segurança e eficiência na atualização de aplicativos, sites e serviços utilizados 
por um grande público. A automação do deploy fornece a capacidade de mover o software entre ambientes de teste e produção usando processos
automatizados, o que leva a implantações repetíveis e confiáveis em todo o ciclo de entrega de software.

A automatização reduz os custos associados ao processo de deploy, pois não é necessário ter uma equipe dedicada para realizar o deploy 
manualmente.
Ela garante que o processo de deploy seja consistente e repetível, reduzindo a possibilidade de erros humanos e garantindo que os 
microsserviços sejam implantados de forma correta e consistente.
Ela também permite que os testes sejam executados automaticamente, garantindo que os microsserviços sejam implantados com uma qualidade 
mais alta e reduzindo a possibilidade de bugs e erros.
Permite que as políticas de segurança sejam aplicadas de forma consistente e repetível, garantindo que os microsserviços sejam implantados
de forma segura e confiável.

## 17 - Qual a importância de definir diferentes ambientes de execução para um microsserviço?

Definir diferentes ambientes de execução para um microsserviços é crucial para garantir a qualidade, segurança e escalabilidade do sistema.
Ambientes de testes permite que os desenvolvedores trabalhem em novas funcionalidades e corrijam bugs sem afetar o ambiente de produção.
Um ambiente de produção é onde o microsserviço é executado em produção, atendendo às solicitações dos usuários.
Desta forma, definir diferentes ambientes para um microsserviço é crucial para garantir a qualidade, segurança e escalabilidade do 
sistema. Cada ambiente tem suas próprias configurações, permitindo que os desenvolvedores trabalhem de forma mais eficiente e garantindo 
que o sistema possa lidar com aumentos de tráfego ou demanda.

## 18 - O que é a estratégia de deploy blue-green e como ela funciona?

A implantação azul-verde ou blue green deployment, é um modelo de lançamento de aplicações que transfere gradualmente o tráfego de 
usuários de uma versão anterior da aplicação ou do microsserviço para uma nova versão praticamente idêntica, também executada em ambiente 
de produção. 
A versão antiga pode ser chamada de "ambiente azul", enquanto a versão nova é chamada de "ambiente verde". Após o tráfego em produção 
ser totalmente transferido do ambiente azul para o verde, o azul pode ser mantido para fins de reversão (rollback) ou retirado do 
ambiente de produção para ser atualizado e se tornar o template para a próxima atualização.

## 19 - Como o uso de feature toggles pode facilitar a gestão de deploys em microsserviços?

Feature toggle é uma estratégia que nos permite fazer integração contínua. Essa estratégia consiste em habilitar e desabilitar 
recursos e funcionalidades em um sistema sem alteração de código e em tempo real.
O uso de feature toggles ajudam para a gestão de deploys em microsserviços em diversos seguimentos, como:
Controle sobre a liberação de funcionalidades
Redução do risco de erros
Flexibilidade e implementação de novas funcionalidades
Testes A/B
