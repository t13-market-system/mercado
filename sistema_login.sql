-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 09/04/2026 às 01:59
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `sistema_login`
--

DELIMITER $$
--
-- Procedimentos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `cadastrar_cliente` (IN `p_nome` VARCHAR(50), IN `p_cpf` VARCHAR(20), IN `p_email` VARCHAR(50), IN `p_telefone` VARCHAR(11), IN `p_pais` VARCHAR(30), IN `p_estado` VARCHAR(30), IN `p_cidade` VARCHAR(30), IN `p_bairro` VARCHAR(50), IN `p_rua` VARCHAR(50), IN `p_numero` VARCHAR(10), IN `p_cep` VARCHAR(20), IN `p_complemento` VARCHAR(20))   BEGIN
    DECLARE v_id_cliente INT;

    START TRANSACTION; 

    INSERT INTO cliente (
        nome_cliente,
        cpf_cliente   
    ) VALUES (
        p_nome,
        p_cpf
   
    );
  
    SET v_id_cliente = LAST_INSERT_ID();
 
 
    INSERT INTO contato_cliente (
        telefone_cliente,
        email_cliente,
        id_cliente
    ) VALUES (
        p_telefone,
        p_email,
        v_id_cliente
    );
 
 
    INSERT INTO endereco_cliente (
        pais_cliente,
        estado_cliente,
        cidade_cliente,
        bairro_cliente,
        rua_cliente,
        numero_cliente,
        cep_cliente,
        complemento_cliente,
        id_cliente
    ) VALUES (
        p_pais,
        p_estado,
        p_cidade,
        p_bairro,
        p_rua,
        p_numero,
        p_cep,
        p_complemento,
        v_id_cliente
    );
 
    COMMIT;
 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cadastrar_fornecedor` (IN `p_nome` VARCHAR(50), IN `p_cnpj` VARCHAR(20), IN `p_email` VARCHAR(50), IN `p_telefone` VARCHAR(11), IN `p_pais` VARCHAR(30), IN `p_estado` VARCHAR(30), IN `p_cidade` VARCHAR(30), IN `p_rua` VARCHAR(50), IN `p_bairro` VARCHAR(50), IN `p_numero` VARCHAR(10), IN `p_cep` VARCHAR(20), IN `p_complemento` VARCHAR(20))   BEGIN
    DECLARE v_id_fornecedor INT;

    -- Inicia transação
    START TRANSACTION;

    -- Inserir fornecedor
    INSERT INTO fornecedor (
        nome_fornecedor,
        cnpj_fornecedor,
        email_fornecedor
    ) VALUES (
        p_nome,
        p_cnpj,
        p_email
    );

    -- Captura o ID gerado
    SET v_id_fornecedor = LAST_INSERT_ID();

    -- Inserir telefone
    INSERT INTO telefone_fornecedor (
        telefone_fornecedor,
        id_fornecedor
    ) VALUES (
        p_telefone,
        v_id_fornecedor
    );

    -- Inserir endereço
    INSERT INTO endereco_fornecedor (
        pais_fornecedor,
        estado_fornecedor,
        cidade_fornecedor,
        rua_fornecedor,
        bairro_fornecedor,
        numero_fornecedor,
        cep_fornecedor,
        complemento_fornecedor,
        id_fornecedor
    ) VALUES (
        p_pais,
        p_estado,
        p_cidade,
        p_rua,
        p_bairro,
        p_numero,
        p_cep,
        p_complemento,
        v_id_fornecedor
    );

    -- Confirma tudo
    COMMIT;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cadastrar_funcionario` (IN `f_nome` VARCHAR(100), IN `f_cpf` VARCHAR(14), IN `f_email` VARCHAR(100), IN `f_id_cargo` INT, IN `f_telefone` VARCHAR(20), IN `f_pais` VARCHAR(50), IN `f_estado` VARCHAR(2), IN `f_cidade` VARCHAR(100), IN `f_rua` VARCHAR(100), IN `f_bairro` VARCHAR(100), IN `f_numero` VARCHAR(20), IN `f_cep` VARCHAR(20), IN `f_complemento` VARCHAR(100))   BEGIN
    DECLARE v_id_funcionario INT;
 
    START TRANSACTION;
 
    INSERT INTO funcionario (nome_funcionario, cpf_funcionario, email_funcionario, id_cargo) 
    VALUES (f_nome, f_cpf, f_email, f_id_cargo);
 
    SET v_id_funcionario = LAST_INSERT_ID();
 
    INSERT INTO contato_funcionario (telefone_funcionario, id_funcionario) 
    VALUES (f_telefone, v_id_funcionario);
 
    INSERT INTO endereco_funcionario (pais_funcionario, estado_funcionario, cidade_funcionario, rua_funcionario, bairro_funcionario, numero_funcionario, cep_funcionario, complemento_funcionario, id_funcionario) 
    VALUES (f_pais, f_estado, f_cidade, f_rua, f_bairro, f_numero, f_cep, f_complemento, v_id_funcionario);
 
    COMMIT;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `cadastrar_produto` (IN `p_nome_produto` VARCHAR(50), IN `p_id_categoria` INT, IN `p_id_fornecedor` INT, IN `p_preco` DECIMAL(10,2), IN `p_codigo` VARCHAR(15), IN `p_qtd` INT, IN `p_n_lote` VARCHAR(50), IN `p_data_validade` DATE, IN `p_local_estoque` VARCHAR(50), IN `p_status` VARCHAR(20))   BEGIN
 
DECLARE v_id_produto INT;
 

INSERT INTO produto(
    nome_produto,
    id_categoria,
    id_fornecedor,
    preco_produto,
    codigo_produto
)
VALUES(
    p_nome_produto,
    p_id_categoria,
    p_id_fornecedor,
    p_preco,
    p_codigo
);
 

SET v_id_produto = LAST_INSERT_ID();
 

INSERT INTO estoque(
    id_produto,
    qtd_produto,
    id_fornecedor,
    n_lote,
    data_validade,
    local_estoque,
    status,
    data_entrada
)
VALUES(
    v_id_produto,
    p_qtd,
    p_id_fornecedor,
    p_n_lote,
    p_data_validade,
    p_local_estoque,
    p_status,
    CURDATE()
);
 commit;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `criar_venda` (IN `p_cpf` INT, IN `p_id_forma_pagamento` INT, IN `p_id_produto` INT, IN `p_quantidade` INT, IN `p_preco` DECIMAL(10,2))   BEGIN

DECLARE v_id_pedido INT;

INSERT INTO pedido (cpf)
VALUES (p_cpf);

SET v_id_pedido = LAST_INSERT_ID();

INSERT INTO venda (
    id_pedido,
    data_venda,
    id_forma_pagamento
)
VALUES (
    v_id_pedido,
    NOW(),
    p_id_forma_pagamento
);

INSERT INTO pedido_item(
    id_pedido,
    id_produto,
    quantidade_item,
    preco_unitario
)
VALUES(
    v_id_pedido,
    p_id_produto,
    p_quantidade,
    p_preco
);
commit;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura para tabela `cargos`
--

CREATE TABLE `cargos` (
  `id_cargo` int(11) NOT NULL,
  `nome_cargo` varchar(20) NOT NULL,
  `salario_funcionario` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `cargos`
--

INSERT INTO `cargos` (`id_cargo`, `nome_cargo`, `salario_funcionario`) VALUES
(1, 'CEO', 30000),
(3, 'Gerente de Loja', 5000),
(4, 'Subgerente', 3500),
(5, 'Supervisor de Setor', 2800),
(6, 'Operador de Caixa', 1600),
(7, 'Repositor', 1500),
(8, 'Auxiliar de Limpeza', 1400),
(9, 'Segurança', 1800),
(10, 'Estoquista', 1700),
(11, 'Atendente de Padaria', 1600),
(12, 'Padeiro', 2200),
(13, 'Confeiteiro', 2500),
(14, 'Açougueiro', 2300),
(15, 'Auxiliar de Açougue', 1600),
(16, 'Hortifruti', 1500),
(17, 'Fiscal de Caixa', 2000),
(18, 'Empacotador', 1300),
(19, 'Assistente Administr', 2100),
(20, 'RH (Recursos Humanos', 3000),
(21, 'Comprador', 3200),
(22, 'TI (Suporte Técnico)', 3500);

-- --------------------------------------------------------

--
-- Estrutura para tabela `categoria`
--

CREATE TABLE `categoria` (
  `id_categoria` int(11) NOT NULL,
  `nome_categoria` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `categoria`
--

INSERT INTO `categoria` (`id_categoria`, `nome_categoria`) VALUES
(1, 'Limpeza'),
(2, 'Alimentos'),
(3, 'Bebidas'),
(4, 'Higiene Pessoal'),
(5, 'Frios'),
(6, 'Padaria'),
(7, 'Frutas e Verduras'),
(8, 'Carnes'),
(9, 'Peixes e Frutos do Mar'),
(10, 'Laticínios'),
(11, 'Congelados'),
(12, 'Grãos e Massas'),
(13, 'Doces e Sobremesas'),
(14, 'Snacks e Salgados'),
(15, 'Produtos Naturais e Orgânicos'),
(16, 'Bebês e Crianças'),
(17, 'Pet Shop'),
(18, 'Utilidades Domésticas'),
(23, 'CongeladosTESTE');

-- --------------------------------------------------------

--
-- Estrutura para tabela `cliente`
--

CREATE TABLE `cliente` (
  `id_cliente` int(11) NOT NULL,
  `nome_cliente` varchar(50) DEFAULT NULL,
  `cpf_cliente` varchar(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `cliente`
--

INSERT INTO `cliente` (`id_cliente`, `nome_cliente`, `cpf_cliente`) VALUES
(1, 'João Silva', '123.456.789'),
(4, 'Paulo Gomes', '333.000.333');

-- --------------------------------------------------------

--
-- Estrutura para tabela `contato_cliente`
--

CREATE TABLE `contato_cliente` (
  `id_contato_cliente` int(11) NOT NULL,
  `telefone_cliente` varchar(15) DEFAULT NULL,
  `email_cliente` varchar(50) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `contato_cliente`
--

INSERT INTO `contato_cliente` (`id_contato_cliente`, `telefone_cliente`, `email_cliente`, `id_cliente`) VALUES
(1, '(11) 99876-5432', 'joao.silva@email.com', 1),
(2, '(12)99999-0', 'paulogomes@gmail.com', 4);

-- --------------------------------------------------------

--
-- Estrutura para tabela `contato_funcionario`
--

CREATE TABLE `contato_funcionario` (
  `id_contato_funcionario` int(11) NOT NULL,
  `telefone_funcionario` varchar(20) NOT NULL,
  `id_funcionario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `contato_funcionario`
--

INSERT INTO `contato_funcionario` (`id_contato_funcionario`, `telefone_funcionario`, `id_funcionario`) VALUES
(1, '(11) 98765-4321', 1),
(2, '(21) 91234-5678', 2),
(3, '12987654309', 11),
(4, '12987698429', 14);

-- --------------------------------------------------------

--
-- Estrutura para tabela `endereco_cliente`
--

CREATE TABLE `endereco_cliente` (
  `id_endereco_cliente` int(11) NOT NULL,
  `pais_cliente` varchar(20) DEFAULT NULL,
  `estado_cliente` varchar(20) DEFAULT NULL,
  `cidade_cliente` varchar(20) DEFAULT NULL,
  `bairro_cliente` varchar(20) DEFAULT NULL,
  `rua_cliente` varchar(20) DEFAULT NULL,
  `numero_cliente` varchar(10) DEFAULT NULL,
  `complemento_cliente` varchar(20) DEFAULT NULL,
  `cep_cliente` varchar(20) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `endereco_cliente`
--

INSERT INTO `endereco_cliente` (`id_endereco_cliente`, `pais_cliente`, `estado_cliente`, `cidade_cliente`, `bairro_cliente`, `rua_cliente`, `numero_cliente`, `complemento_cliente`, `cep_cliente`, `id_cliente`) VALUES
(1, 'Brasil', 'SP', 'São Paulo', 'Centro', 'Av. Paulista', '1000', 'Apto 101', '01310-100', 1),
(2, 'Brasil', 'São Paulo', 'Taubate', 'Gorilandia', 'Rua Jose Tibiriça', '212', 'Apto B-4', '12.444.333', 4);

-- --------------------------------------------------------

--
-- Estrutura para tabela `endereco_fornecedor`
--

CREATE TABLE `endereco_fornecedor` (
  `id_endereco_fornecedor` int(11) NOT NULL,
  `rua_fornecedor` varchar(50) NOT NULL,
  `bairro_fornecedor` varchar(50) NOT NULL,
  `numero_fornecedor` varchar(10) NOT NULL,
  `complemento_fornecedor` varchar(20) DEFAULT NULL,
  `cep_fornecedor` varchar(20) NOT NULL,
  `cidade_fornecedor` varchar(20) NOT NULL,
  `estado_fornecedor` varchar(20) NOT NULL,
  `pais_fornecedor` varchar(20) NOT NULL,
  `id_fornecedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `endereco_fornecedor`
--

INSERT INTO `endereco_fornecedor` (`id_endereco_fornecedor`, `rua_fornecedor`, `bairro_fornecedor`, `numero_fornecedor`, `complemento_fornecedor`, `cep_fornecedor`, `cidade_fornecedor`, `estado_fornecedor`, `pais_fornecedor`, `id_fornecedor`) VALUES
(1, 'Rua das Palmeiras', 'Centro', '123', 'Sala 45', '01010-000', 'São Paulo', 'SP', 'Brasil', 1),
(2, 'Rua das Flores', 'Centro', '100', '', '01000-000', 'São Paulo', 'SP', 'Brasil', 100),
(3, 'Av. Paulista', 'Bela Vista', '101', 'Sala 2', '01310-000', 'São Paulo', 'SP', 'Brasil', 101),
(4, 'Rua A', 'Mooca', '102', '', '03100-000', 'São Paulo', 'SP', 'Brasil', 102),
(5, 'Rua B', 'Ipiranga', '103', '', '04200-000', 'São Paulo', 'SP', 'Brasil', 103),
(6, 'Rua C', 'Vila Mariana', '104', '', '04000-000', 'São Paulo', 'SP', 'Brasil', 104),
(7, 'Rua D', 'Pinheiros', '105', '', '05400-000', 'São Paulo', 'SP', 'Brasil', 105),
(8, 'Rua E', 'Lapa', '106', '', '05000-000', 'São Paulo', 'SP', 'Brasil', 106),
(9, 'Rua F', 'Santana', '107', '', '02000-000', 'São Paulo', 'SP', 'Brasil', 107),
(10, 'Rua G', 'Tatuapé', '108', '', '03300-000', 'São Paulo', 'SP', 'Brasil', 108),
(11, 'Rua H', 'Centro', '109', '', '01000-001', 'São Paulo', 'SP', 'Brasil', 109),
(12, 'Rua I', 'Mooca', '110', '', '03100-001', 'São Paulo', 'SP', 'Brasil', 110),
(13, 'Rua J', 'Ipiranga', '111', '', '04200-001', 'São Paulo', 'SP', 'Brasil', 111),
(14, 'Rua K', 'Vila Mariana', '112', '', '04000-001', 'São Paulo', 'SP', 'Brasil', 112),
(15, 'Rua L', 'Pinheiros', '113', '', '05400-001', 'São Paulo', 'SP', 'Brasil', 113),
(16, 'Rua M', 'Lapa', '114', '', '05000-001', 'São Paulo', 'SP', 'Brasil', 114),
(17, 'Rua N', 'Santana', '115', '', '02000-001', 'São Paulo', 'SP', 'Brasil', 115),
(18, 'Rua O', 'Tatuapé', '116', '', '03300-001', 'São Paulo', 'SP', 'Brasil', 116),
(19, 'Rua P', 'Centro', '117', '', '01000-002', 'São Paulo', 'SP', 'Brasil', 117),
(20, 'Rua Q', 'Mooca', '118', '', '03100-002', 'São Paulo', 'SP', 'Brasil', 118),
(21, 'Rua R', 'Ipiranga', '119', '', '04200-002', 'São Paulo', 'SP', 'Brasil', 119),
(22, 'Rua dos Alimentos', 'Centro', '120', '', '01010-000', 'São Paulo', 'SP', 'Brasil', 120),
(23, 'Av. Brasil', 'Jardins', '121', '', '01400-000', 'São Paulo', 'SP', 'Brasil', 121),
(24, 'Rua A1', 'Mooca', '122', '', '03110-000', 'São Paulo', 'SP', 'Brasil', 122),
(25, 'Rua B1', 'Ipiranga', '123', '', '04210-000', 'São Paulo', 'SP', 'Brasil', 123),
(26, 'Rua C1', 'Vila Mariana', '124', '', '04010-000', 'São Paulo', 'SP', 'Brasil', 124),
(27, 'Rua D1', 'Pinheiros', '125', '', '05410-000', 'São Paulo', 'SP', 'Brasil', 125),
(28, 'Rua E1', 'Lapa', '126', '', '05010-000', 'São Paulo', 'SP', 'Brasil', 126),
(29, 'Rua F1', 'Santana', '127', '', '02010-000', 'São Paulo', 'SP', 'Brasil', 127),
(30, 'Rua G1', 'Tatuapé', '128', '', '03310-000', 'São Paulo', 'SP', 'Brasil', 128),
(31, 'Rua H1', 'Centro', '129', '', '01010-001', 'São Paulo', 'SP', 'Brasil', 129),
(32, 'Rua I1', 'Mooca', '130', '', '03110-001', 'São Paulo', 'SP', 'Brasil', 130),
(33, 'Rua J1', 'Ipiranga', '131', '', '04210-001', 'São Paulo', 'SP', 'Brasil', 131),
(34, 'Rua K1', 'Vila Mariana', '132', '', '04010-001', 'São Paulo', 'SP', 'Brasil', 132),
(35, 'Rua L1', 'Pinheiros', '133', '', '05410-001', 'São Paulo', 'SP', 'Brasil', 133),
(36, 'Rua M1', 'Lapa', '134', '', '05010-001', 'São Paulo', 'SP', 'Brasil', 134),
(37, 'Rua N1', 'Santana', '135', '', '02010-001', 'São Paulo', 'SP', 'Brasil', 135),
(38, 'Rua O1', 'Tatuapé', '136', '', '03310-001', 'São Paulo', 'SP', 'Brasil', 136),
(39, 'Rua P1', 'Centro', '137', '', '01010-002', 'São Paulo', 'SP', 'Brasil', 137),
(40, 'Rua Q1', 'Mooca', '138', '', '03110-002', 'São Paulo', 'SP', 'Brasil', 138),
(41, 'Rua R1', 'Ipiranga', '139', '', '04210-002', 'São Paulo', 'SP', 'Brasil', 139),
(42, 'Rua das Águas', 'Centro', '140', '', '01020-000', 'São Paulo', 'SP', 'Brasil', 140),
(43, 'Av. Paulista', 'Bela Vista', '141', 'Sala 10', '01311-000', 'São Paulo', 'SP', 'Brasil', 141),
(44, 'Rua A2', 'Mooca', '142', '', '03120-000', 'São Paulo', 'SP', 'Brasil', 142),
(45, 'Rua B2', 'Ipiranga', '143', '', '04220-000', 'São Paulo', 'SP', 'Brasil', 143),
(46, 'Rua C2', 'Vila Mariana', '144', '', '04020-000', 'São Paulo', 'SP', 'Brasil', 144),
(47, 'Rua D2', 'Pinheiros', '145', '', '05420-000', 'São Paulo', 'SP', 'Brasil', 145),
(48, 'Rua E2', 'Lapa', '146', '', '05020-000', 'São Paulo', 'SP', 'Brasil', 146),
(49, 'Rua F2', 'Santana', '147', '', '02020-000', 'São Paulo', 'SP', 'Brasil', 147),
(50, 'Rua G2', 'Tatuapé', '148', '', '03320-000', 'São Paulo', 'SP', 'Brasil', 148),
(51, 'Rua H2', 'Centro', '149', '', '01020-001', 'São Paulo', 'SP', 'Brasil', 149),
(52, 'Rua I2', 'Mooca', '150', '', '03120-001', 'São Paulo', 'SP', 'Brasil', 150),
(53, 'Rua J2', 'Ipiranga', '151', '', '04220-001', 'São Paulo', 'SP', 'Brasil', 151),
(54, 'Rua K2', 'Vila Mariana', '152', '', '04020-001', 'São Paulo', 'SP', 'Brasil', 152),
(55, 'Rua L2', 'Pinheiros', '153', '', '05420-001', 'São Paulo', 'SP', 'Brasil', 153),
(56, 'Rua M2', 'Lapa', '154', '', '05020-001', 'São Paulo', 'SP', 'Brasil', 154),
(57, 'Rua N2', 'Santana', '155', '', '02020-001', 'São Paulo', 'SP', 'Brasil', 155),
(58, 'Rua O2', 'Tatuapé', '156', '', '03320-001', 'São Paulo', 'SP', 'Brasil', 156),
(59, 'Rua P2', 'Centro', '157', '', '01020-002', 'São Paulo', 'SP', 'Brasil', 157),
(60, 'Rua Q2', 'Mooca', '158', '', '03120-002', 'São Paulo', 'SP', 'Brasil', 158),
(61, 'Rua R2', 'Ipiranga', '159', '', '04220-002', 'São Paulo', 'SP', 'Brasil', 159),
(62, 'Rua das Flores', 'Centro', '160', '', '01030-000', 'São Paulo', 'SP', 'Brasil', 160),
(63, 'Av. Paulista', 'Bela Vista', '161', 'Sala 5', '01312-000', 'São Paulo', 'SP', 'Brasil', 161),
(64, 'Rua A3', 'Mooca', '162', '', '03130-000', 'São Paulo', 'SP', 'Brasil', 162),
(65, 'Rua B3', 'Ipiranga', '163', '', '04230-000', 'São Paulo', 'SP', 'Brasil', 163),
(66, 'Rua C3', 'Vila Mariana', '164', '', '04030-000', 'São Paulo', 'SP', 'Brasil', 164),
(67, 'Rua D3', 'Pinheiros', '165', '', '05430-000', 'São Paulo', 'SP', 'Brasil', 165),
(68, 'Rua E3', 'Lapa', '166', '', '05030-000', 'São Paulo', 'SP', 'Brasil', 166),
(69, 'Rua F3', 'Santana', '167', '', '02030-000', 'São Paulo', 'SP', 'Brasil', 167),
(70, 'Rua G3', 'Tatuapé', '168', '', '03330-000', 'São Paulo', 'SP', 'Brasil', 168),
(71, 'Rua H3', 'Centro', '169', '', '01030-001', 'São Paulo', 'SP', 'Brasil', 169),
(72, 'Rua I3', 'Mooca', '170', '', '03130-001', 'São Paulo', 'SP', 'Brasil', 170),
(73, 'Rua J3', 'Ipiranga', '171', '', '04230-001', 'São Paulo', 'SP', 'Brasil', 171),
(74, 'Rua K3', 'Vila Mariana', '172', '', '04030-001', 'São Paulo', 'SP', 'Brasil', 172),
(75, 'Rua L3', 'Pinheiros', '173', '', '05430-001', 'São Paulo', 'SP', 'Brasil', 173),
(76, 'Rua M3', 'Lapa', '174', '', '05030-001', 'São Paulo', 'SP', 'Brasil', 174),
(77, 'Rua N3', 'Santana', '175', '', '02030-001', 'São Paulo', 'SP', 'Brasil', 175),
(78, 'Rua O3', 'Tatuapé', '176', '', '03330-001', 'São Paulo', 'SP', 'Brasil', 176),
(79, 'Rua P3', 'Centro', '177', '', '01030-002', 'São Paulo', 'SP', 'Brasil', 177),
(80, 'Rua Q3', 'Mooca', '178', '', '03130-002', 'São Paulo', 'SP', 'Brasil', 178),
(81, 'Rua R3', 'Ipiranga', '179', '', '04230-002', 'São Paulo', 'SP', 'Brasil', 179),
(82, 'Rua das Carnes', 'Centro', '180', '', '01040-000', 'São Paulo', 'SP', 'Brasil', 180),
(83, 'Av. Paulista', 'Bela Vista', '181', 'Sala 8', '01313-000', 'São Paulo', 'SP', 'Brasil', 181),
(84, 'Rua A4', 'Mooca', '182', '', '03140-000', 'São Paulo', 'SP', 'Brasil', 182),
(85, 'Rua B4', 'Ipiranga', '183', '', '04240-000', 'São Paulo', 'SP', 'Brasil', 183),
(86, 'Rua C4', 'Vila Mariana', '184', '', '04040-000', 'São Paulo', 'SP', 'Brasil', 184),
(87, 'Rua D4', 'Pinheiros', '185', '', '05440-000', 'São Paulo', 'SP', 'Brasil', 185),
(88, 'Rua E4', 'Lapa', '186', '', '05040-000', 'São Paulo', 'SP', 'Brasil', 186),
(89, 'Rua F4', 'Santana', '187', '', '02040-000', 'São Paulo', 'SP', 'Brasil', 187),
(90, 'Rua G4', 'Tatuapé', '188', '', '03340-000', 'São Paulo', 'SP', 'Brasil', 188),
(91, 'Rua H4', 'Centro', '189', '', '01040-001', 'São Paulo', 'SP', 'Brasil', 189),
(92, 'Rua I4', 'Mooca', '190', '', '03140-001', 'São Paulo', 'SP', 'Brasil', 190),
(93, 'Rua J4', 'Ipiranga', '191', '', '04240-001', 'São Paulo', 'SP', 'Brasil', 191),
(94, 'Rua K4', 'Vila Mariana', '192', '', '04040-001', 'São Paulo', 'SP', 'Brasil', 192),
(95, 'Rua L4', 'Pinheiros', '193', '', '05440-001', 'São Paulo', 'SP', 'Brasil', 193),
(96, 'Rua M4', 'Lapa', '194', '', '05040-001', 'São Paulo', 'SP', 'Brasil', 194),
(97, 'Rua N4', 'Santana', '195', '', '02040-001', 'São Paulo', 'SP', 'Brasil', 195),
(98, 'Rua O4', 'Tatuapé', '196', '', '03340-001', 'São Paulo', 'SP', 'Brasil', 196),
(99, 'Rua P4', 'Centro', '197', '', '01040-002', 'São Paulo', 'SP', 'Brasil', 197),
(100, 'Rua Q4', 'Mooca', '198', '', '03140-002', 'São Paulo', 'SP', 'Brasil', 198),
(101, 'Rua R4', 'Ipiranga', '199', '', '04240-002', 'São Paulo', 'SP', 'Brasil', 199),
(102, 'Rua do Trigo', 'Centro', '200', '', '01050-000', 'São Paulo', 'SP', 'Brasil', 200),
(103, 'Av. Paulista', 'Bela Vista', '201', 'Sala 12', '01314-000', 'São Paulo', 'SP', 'Brasil', 201),
(104, 'Rua A5', 'Mooca', '202', '', '03150-000', 'São Paulo', 'SP', 'Brasil', 202),
(105, 'Rua B5', 'Ipiranga', '203', '', '04250-000', 'São Paulo', 'SP', 'Brasil', 203),
(106, 'Rua C5', 'Vila Mariana', '204', '', '04050-000', 'São Paulo', 'SP', 'Brasil', 204),
(107, 'Rua D5', 'Pinheiros', '205', '', '05450-000', 'São Paulo', 'SP', 'Brasil', 205),
(108, 'Rua E5', 'Lapa', '206', '', '05050-000', 'São Paulo', 'SP', 'Brasil', 206),
(109, 'Rua F5', 'Santana', '207', '', '02050-000', 'São Paulo', 'SP', 'Brasil', 207),
(110, 'Rua G5', 'Tatuapé', '208', '', '03350-000', 'São Paulo', 'SP', 'Brasil', 208),
(111, 'Rua H5', 'Centro', '209', '', '01050-001', 'São Paulo', 'SP', 'Brasil', 209),
(112, 'Rua I5', 'Mooca', '210', '', '03150-001', 'São Paulo', 'SP', 'Brasil', 210),
(113, 'Rua J5', 'Ipiranga', '211', '', '04250-001', 'São Paulo', 'SP', 'Brasil', 211),
(114, 'Rua K5', 'Vila Mariana', '212', '', '04050-001', 'São Paulo', 'SP', 'Brasil', 212),
(115, 'Rua L5', 'Pinheiros', '213', '', '05450-001', 'São Paulo', 'SP', 'Brasil', 213),
(116, 'Rua M5', 'Lapa', '214', '', '05050-001', 'São Paulo', 'SP', 'Brasil', 214),
(117, 'Rua N5', 'Santana', '215', '', '02050-001', 'São Paulo', 'SP', 'Brasil', 215),
(118, 'Rua O5', 'Tatuapé', '216', '', '03350-001', 'São Paulo', 'SP', 'Brasil', 216),
(119, 'Rua P5', 'Centro', '217', '', '01050-002', 'São Paulo', 'SP', 'Brasil', 217),
(120, 'Rua Q5', 'Mooca', '218', '', '03150-002', 'São Paulo', 'SP', 'Brasil', 218),
(121, 'Rua R5', 'Ipiranga', '219', '', '04250-002', 'São Paulo', 'SP', 'Brasil', 219),
(122, 'Rua das Frutas', 'Centro', '220', '', '01060-001', 'São Paulo', 'SP', 'Brasil', 220),
(123, 'Av. das Palmeiras', 'Bela Vista', '221', 'Sala 10', '01316-001', 'São Paulo', 'SP', 'Brasil', 221),
(124, 'Rua dos Pomares', 'Mooca', '222', '', '03160-002', 'São Paulo', 'SP', 'Brasil', 222),
(125, 'Rua Hortelã', 'Ipiranga', '223', '', '04260-003', 'São Paulo', 'SP', 'Brasil', 223),
(126, 'Rua das Laranjeiras', 'Vila Mariana', '224', '', '04060-004', 'São Paulo', 'SP', 'Brasil', 224),
(127, 'Rua Verdejante', 'Pinheiros', '225', '', '05460-005', 'São Paulo', 'SP', 'Brasil', 225),
(128, 'Rua do Pomar', 'Lapa', '226', '', '05060-006', 'São Paulo', 'SP', 'Brasil', 226),
(129, 'Rua do Campo', 'Santana', '227', '', '02060-007', 'São Paulo', 'SP', 'Brasil', 227),
(130, 'Rua Tropical', 'Tatuapé', '228', '', '03360-008', 'São Paulo', 'SP', 'Brasil', 228),
(131, 'Rua das Palmeiras', 'Centro', '229', '', '01060-009', 'São Paulo', 'SP', 'Brasil', 229),
(132, 'Rua do Sol', 'Mooca', '230', '', '03160-010', 'São Paulo', 'SP', 'Brasil', 230),
(133, 'Rua Verdejante II', 'Ipiranga', '231', '', '04260-011', 'São Paulo', 'SP', 'Brasil', 231),
(134, 'Rua das Flores', 'Vila Mariana', '232', '', '04060-012', 'São Paulo', 'SP', 'Brasil', 232),
(135, 'Rua do Pomar II', 'Pinheiros', '233', '', '05460-013', 'São Paulo', 'SP', 'Brasil', 233),
(136, 'Rua dos Jardins', 'Lapa', '234', '', '05060-014', 'São Paulo', 'SP', 'Brasil', 234),
(137, 'Rua Campo Verde', 'Santana', '235', '', '02060-015', 'São Paulo', 'SP', 'Brasil', 235),
(138, 'Rua Tropical II', 'Tatuapé', '236', '', '03360-016', 'São Paulo', 'SP', 'Brasil', 236),
(139, 'Rua Hortifruti', 'Centro', '237', '', '01060-017', 'São Paulo', 'SP', 'Brasil', 237),
(140, 'Rua Pomar Verde', 'Mooca', '238', '', '03160-018', 'São Paulo', 'SP', 'Brasil', 238),
(141, 'Rua Top Verde', 'Ipiranga', '239', '', '04260-019', 'São Paulo', 'SP', 'Brasil', 239),
(142, 'Rua do Boi', 'Centro', '240', '', '01070-001', 'São Paulo', 'SP', 'Brasil', 240),
(143, 'Rua do Frigorífico', 'Bela Vista', '241', 'Sala 10', '01316-002', 'São Paulo', 'SP', 'Brasil', 241),
(144, 'Rua do Gado', 'Mooca', '242', '', '03170-003', 'São Paulo', 'SP', 'Brasil', 242),
(145, 'Rua da Carne', 'Ipiranga', '243', '', '04270-004', 'São Paulo', 'SP', 'Brasil', 243),
(146, 'Rua Premium', 'Vila Mariana', '244', '', '04070-005', 'São Paulo', 'SP', 'Brasil', 244),
(147, 'Rua Bovina', 'Pinheiros', '245', '', '05470-006', 'São Paulo', 'SP', 'Brasil', 245),
(148, 'Rua Delícia', 'Lapa', '246', '', '05070-007', 'São Paulo', 'SP', 'Brasil', 246),
(149, 'Rua Expressa', 'Santana', '247', '', '02070-008', 'São Paulo', 'SP', 'Brasil', 247),
(150, 'Rua Top', 'Tatuapé', '248', '', '03370-009', 'São Paulo', 'SP', 'Brasil', 248),
(151, 'Rua Paulista', 'Centro', '249', '', '01070-010', 'São Paulo', 'SP', 'Brasil', 249),
(152, 'Rua União', 'Mooca', '250', '', '03170-011', 'São Paulo', 'SP', 'Brasil', 250),
(153, 'Rua Mais', 'Ipiranga', '251', '', '04270-012', 'São Paulo', 'SP', 'Brasil', 251),
(154, 'Rua Sul Premium', 'Vila Mariana', '252', '', '04070-013', 'São Paulo', 'SP', 'Brasil', 252),
(155, 'Rua Arte Sabor', 'Pinheiros', '253', '', '05470-014', 'São Paulo', 'SP', 'Brasil', 253),
(156, 'Rua Central', 'Lapa', '254', '', '05070-015', 'São Paulo', 'SP', 'Brasil', 254),
(157, 'Rua Prime', 'Santana', '255', '', '02070-016', 'São Paulo', 'SP', 'Brasil', 255),
(158, 'Rua Delicatessen', 'Tatuapé', '256', '', '03370-017', 'São Paulo', 'SP', 'Brasil', 256),
(159, 'Rua Master', 'Centro', '257', '', '01070-018', 'São Paulo', 'SP', 'Brasil', 257),
(160, 'Rua Comercial', 'Mooca', '258', '', '03170-019', 'São Paulo', 'SP', 'Brasil', 258),
(161, 'Rua Paulista Premium', 'Ipiranga', '259', '', '04270-020', 'São Paulo', 'SP', 'Brasil', 259),
(162, 'Rua dos Peixes', 'Centro', '260', '', '01080-001', 'São Paulo', 'SP', 'Brasil', 260),
(163, 'Rua do Mar', 'Bela Vista', '261', '', '01317-002', 'São Paulo', 'SP', 'Brasil', 261),
(164, 'Rua Oceânica', 'Mooca', '262', '', '03180-003', 'São Paulo', 'SP', 'Brasil', 262),
(165, 'Rua do Marinheiro', 'Ipiranga', '263', '', '04280-004', 'São Paulo', 'SP', 'Brasil', 263),
(166, 'Rua dos Mariscos', 'Vila Mariana', '264', '', '04080-005', 'São Paulo', 'SP', 'Brasil', 264),
(167, 'Rua Atlântico', 'Pinheiros', '265', '', '05480-006', 'São Paulo', 'SP', 'Brasil', 265),
(168, 'Rua Peixaria', 'Lapa', '266', '', '05080-007', 'São Paulo', 'SP', 'Brasil', 266),
(169, 'Rua Oceano Azul', 'Santana', '267', '', '02080-008', 'São Paulo', 'SP', 'Brasil', 267),
(170, 'Rua Top Mar', 'Tatuapé', '268', '', '03380-009', 'São Paulo', 'SP', 'Brasil', 268),
(171, 'Rua Marinha', 'Centro', '269', '', '01080-010', 'São Paulo', 'SP', 'Brasil', 269),
(172, 'Rua União do Mar', 'Mooca', '270', '', '03180-011', 'São Paulo', 'SP', 'Brasil', 270),
(173, 'Rua Mar Mais', 'Ipiranga', '271', '', '04280-012', 'São Paulo', 'SP', 'Brasil', 271),
(174, 'Rua Oceano Sul', 'Vila Mariana', '272', '', '04080-013', 'São Paulo', 'SP', 'Brasil', 272),
(175, 'Rua Sabor Mar', 'Pinheiros', '273', '', '05480-014', 'São Paulo', 'SP', 'Brasil', 273),
(176, 'Rua Central Mar', 'Lapa', '274', '', '05080-015', 'São Paulo', 'SP', 'Brasil', 274),
(177, 'Rua Mar Prime', 'Santana', '275', '', '02080-016', 'São Paulo', 'SP', 'Brasil', 275),
(178, 'Rua Delicatessen Mar', 'Tatuapé', '276', '', '03380-017', 'São Paulo', 'SP', 'Brasil', 276),
(179, 'Rua Master Mar', 'Centro', '277', '', '01080-018', 'São Paulo', 'SP', 'Brasil', 277),
(180, 'Rua Comercial Mar', 'Mooca', '278', '', '03180-019', 'São Paulo', 'SP', 'Brasil', 278),
(181, 'Rua Paulista Mar', 'Ipiranga', '279', '', '04280-020', 'São Paulo', 'SP', 'Brasil', 279),
(182, 'Rua do Leite Fresco', 'Centro', '280', '', '01090-001', 'São Paulo', 'SP', 'Brasil', 280),
(183, 'Rua Queijo Minas', 'Bela Vista', '281', '', '01318-002', 'São Paulo', 'SP', 'Brasil', 281),
(184, 'Rua do Laticínio', 'Mooca', '282', '', '03190-003', 'São Paulo', 'SP', 'Brasil', 282),
(185, 'Rua Delícia do Campo', 'Ipiranga', '283', '', '04290-004', 'São Paulo', 'SP', 'Brasil', 283),
(186, 'Rua Premium Queijo', 'Vila Mariana', '284', '', '04090-005', 'São Paulo', 'SP', 'Brasil', 284),
(187, 'Rua União do Leite', 'Pinheiros', '285', '', '05490-006', 'São Paulo', 'SP', 'Brasil', 285),
(188, 'Rua Leite do Vale', 'Lapa', '286', '', '05090-007', 'São Paulo', 'SP', 'Brasil', 286),
(189, 'Rua Delicatessen', 'Santana', '287', '', '02090-008', 'São Paulo', 'SP', 'Brasil', 287),
(190, 'Rua Master Laticínios', 'Tatuapé', '288', '', '03390-009', 'São Paulo', 'SP', 'Brasil', 288),
(191, 'Rua Leite e Cia', 'Centro', '289', '', '01090-010', 'São Paulo', 'SP', 'Brasil', 289),
(192, 'Rua Queijaria Paulista', 'Mooca', '290', '', '03190-011', 'São Paulo', 'SP', 'Brasil', 290),
(193, 'Rua Sabor Real', 'Ipiranga', '291', '', '04290-012', 'São Paulo', 'SP', 'Brasil', 291),
(194, 'Rua Leite Natural', 'Vila Mariana', '292', '', '04090-013', 'São Paulo', 'SP', 'Brasil', 292),
(195, 'Rua Queijos Artesanais', 'Pinheiros', '293', '', '05490-014', 'São Paulo', 'SP', 'Brasil', 293),
(196, 'Rua Central Laticínios', 'Lapa', '294', '', '05090-015', 'São Paulo', 'SP', 'Brasil', 294),
(197, 'Rua Leite Prime', 'Santana', '295', '', '02090-016', 'São Paulo', 'SP', 'Brasil', 295),
(198, 'Rua Queijos Delícias', 'Tatuapé', '296', '', '03390-017', 'São Paulo', 'SP', 'Brasil', 296),
(199, 'Rua Top Laticínios', 'Centro', '297', '', '01090-018', 'São Paulo', 'SP', 'Brasil', 297),
(200, 'Rua Leite Comercial', 'Mooca', '298', '', '03190-019', 'São Paulo', 'SP', 'Brasil', 298),
(201, 'Rua Paulista Premium', 'Ipiranga', '299', '', '04290-020', 'São Paulo', 'SP', 'Brasil', 299),
(202, 'Rua do Gelo', 'Centro', '300', '', '01091-001', 'São Paulo', 'SP', 'Brasil', 300),
(203, 'Rua Freezer', 'Bela Vista', '301', '', '01319-002', 'São Paulo', 'SP', 'Brasil', 301),
(204, 'Rua Congelados', 'Mooca', '302', '', '03191-003', 'São Paulo', 'SP', 'Brasil', 302),
(205, 'Rua Frost', 'Ipiranga', '303', '', '04291-004', 'São Paulo', 'SP', 'Brasil', 303),
(206, 'Rua Gelados', 'Vila Mariana', '304', '', '04091-005', 'São Paulo', 'SP', 'Brasil', 304),
(207, 'Rua Freezer Plus', 'Pinheiros', '305', '', '05491-006', 'São Paulo', 'SP', 'Brasil', 305),
(208, 'Rua Congelados Mais', 'Lapa', '306', '', '05091-007', 'São Paulo', 'SP', 'Brasil', 306),
(209, 'Rua Express', 'Santana', '307', '', '02091-008', 'São Paulo', 'SP', 'Brasil', 307),
(210, 'Rua Top Freezer', 'Tatuapé', '308', '', '03391-009', 'São Paulo', 'SP', 'Brasil', 308),
(211, 'Rua Freezer Brasil', 'Centro', '309', '', '01091-010', 'São Paulo', 'SP', 'Brasil', 309),
(212, 'Rua União Congelados', 'Mooca', '310', '', '03191-011', 'São Paulo', 'SP', 'Brasil', 310),
(213, 'Rua Freezer Mais', 'Ipiranga', '311', '', '04291-012', 'São Paulo', 'SP', 'Brasil', 311),
(214, 'Rua Sul Congelados', 'Vila Mariana', '312', '', '04091-013', 'São Paulo', 'SP', 'Brasil', 312),
(215, 'Rua Gelados Sabor', 'Pinheiros', '313', '', '05491-014', 'São Paulo', 'SP', 'Brasil', 313),
(216, 'Rua Central Congelados', 'Lapa', '314', '', '05091-015', 'São Paulo', 'SP', 'Brasil', 314),
(217, 'Rua Frost Premium', 'Santana', '315', '', '02091-016', 'São Paulo', 'SP', 'Brasil', 315),
(218, 'Rua Delicatessen', 'Tatuapé', '316', '', '03391-017', 'São Paulo', 'SP', 'Brasil', 316),
(219, 'Rua Master Freezer', 'Centro', '317', '', '01091-018', 'São Paulo', 'SP', 'Brasil', 317),
(220, 'Rua Comercial Congelados', 'Mooca', '318', '', '03191-019', 'São Paulo', 'SP', 'Brasil', 318),
(221, 'Rua Paulista Congelados', 'Ipiranga', '319', '', '04291-020', 'São Paulo', 'SP', 'Brasil', 319),
(222, 'Rua dos Grãos', 'Centro', '320', '', '01092-001', 'São Paulo', 'SP', 'Brasil', 320),
(223, 'Rua das Massas', 'Bela Vista', '321', '', '01320-002', 'São Paulo', 'SP', 'Brasil', 321),
(224, 'Rua Grão Fino', 'Mooca', '322', '', '03192-003', 'São Paulo', 'SP', 'Brasil', 322),
(225, 'Rua Massa Fresca', 'Ipiranga', '323', '', '04292-004', 'São Paulo', 'SP', 'Brasil', 323),
(226, 'Rua Grãos Premium', 'Vila Mariana', '324', '', '04092-005', 'São Paulo', 'SP', 'Brasil', 324),
(227, 'Rua Massas Express', 'Pinheiros', '325', '', '05492-006', 'São Paulo', 'SP', 'Brasil', 325),
(228, 'Rua União dos Grãos', 'Lapa', '326', '', '05092-007', 'São Paulo', 'SP', 'Brasil', 326),
(229, 'Rua Massas Mais', 'Santana', '327', '', '02092-008', 'São Paulo', 'SP', 'Brasil', 327),
(230, 'Rua Grãos Sabor', 'Tatuapé', '328', '', '03392-009', 'São Paulo', 'SP', 'Brasil', 328),
(231, 'Rua Central Grãos', 'Centro', '329', '', '01092-010', 'São Paulo', 'SP', 'Brasil', 329),
(232, 'Rua Massas Prime', 'Mooca', '330', '', '03192-011', 'São Paulo', 'SP', 'Brasil', 330),
(233, 'Rua Grãos Delicatessen', 'Ipiranga', '331', '', '04292-012', 'São Paulo', 'SP', 'Brasil', 331),
(234, 'Rua Massas Top', 'Vila Mariana', '332', '', '04092-013', 'São Paulo', 'SP', 'Brasil', 332),
(235, 'Rua Grãos Master', 'Pinheiros', '333', '', '05492-014', 'São Paulo', 'SP', 'Brasil', 333),
(236, 'Rua Massas Comercial', 'Lapa', '334', '', '05092-015', 'São Paulo', 'SP', 'Brasil', 334),
(237, 'Rua Grãos Paulista', 'Santana', '335', '', '02092-016', 'São Paulo', 'SP', 'Brasil', 335),
(238, 'Rua Massas Artesanais', 'Tatuapé', '336', '', '03392-017', 'São Paulo', 'SP', 'Brasil', 336),
(239, 'Rua Grãos Sul', 'Centro', '337', '', '01092-018', 'São Paulo', 'SP', 'Brasil', 337),
(240, 'Rua Massas Sabor Arte', 'Mooca', '338', '', '03192-019', 'São Paulo', 'SP', 'Brasil', 338),
(241, 'Rua Grãos Central', 'Ipiranga', '339', '', '04292-020', 'São Paulo', 'SP', 'Brasil', 339),
(242, 'Rua do Açúcar', 'Centro', '340', '', '01093-001', 'São Paulo', 'SP', 'Brasil', 340),
(243, 'Rua Sobremesa', 'Bela Vista', '341', '', '01321-002', 'São Paulo', 'SP', 'Brasil', 341),
(244, 'Rua Confeitaria', 'Mooca', '342', '', '03193-003', 'São Paulo', 'SP', 'Brasil', 342),
(245, 'Rua Doces Premium', 'Ipiranga', '343', '', '04293-004', 'São Paulo', 'SP', 'Brasil', 343),
(246, 'Rua Sobremesas Mais', 'Vila Mariana', '344', '', '04093-005', 'São Paulo', 'SP', 'Brasil', 344),
(247, 'Rua Doces & Cia', 'Pinheiros', '345', '', '05493-006', 'São Paulo', 'SP', 'Brasil', 345),
(248, 'Rua Delícias do Açúcar', 'Lapa', '346', '', '05093-007', 'São Paulo', 'SP', 'Brasil', 346),
(249, 'Rua Sobremesas Express', 'Santana', '347', '', '02093-008', 'São Paulo', 'SP', 'Brasil', 347),
(250, 'Rua Doces Master', 'Tatuapé', '348', '', '03393-009', 'São Paulo', 'SP', 'Brasil', 348),
(251, 'Rua Sobremesas Paulista', 'Centro', '349', '', '01093-010', 'São Paulo', 'SP', 'Brasil', 349),
(252, 'Rua Confeitaria União', 'Mooca', '350', '', '03193-011', 'São Paulo', 'SP', 'Brasil', 350),
(253, 'Rua Doces Mais', 'Ipiranga', '351', '', '04293-012', 'São Paulo', 'SP', 'Brasil', 351),
(254, 'Rua Sobremesas Delicatessen', 'Vila Mariana', '352', '', '04093-013', 'São Paulo', 'SP', 'Brasil', 352),
(255, 'Rua Doces Top', 'Pinheiros', '353', '', '05493-014', 'São Paulo', 'SP', 'Brasil', 353),
(256, 'Rua Sobremesas Sabor', 'Lapa', '354', '', '05093-015', 'São Paulo', 'SP', 'Brasil', 354),
(257, 'Rua Doces Central', 'Santana', '355', '', '02093-016', 'São Paulo', 'SP', 'Brasil', 355),
(258, 'Rua Sobremesas Prime', 'Tatuapé', '356', '', '03393-017', 'São Paulo', 'SP', 'Brasil', 356),
(259, 'Rua Doces Delicatessen', 'Centro', '357', '', '01093-018', 'São Paulo', 'SP', 'Brasil', 357),
(260, 'Rua Sobremesas Master', 'Mooca', '358', '', '03193-019', 'São Paulo', 'SP', 'Brasil', 358),
(261, 'Rua Doces Comercial', 'Ipiranga', '359', '', '04293-020', 'São Paulo', 'SP', 'Brasil', 359),
(262, 'Rua dos Salgados', 'Centro', '360', '', '01094-001', 'São Paulo', 'SP', 'Brasil', 360),
(263, 'Rua dos Snacks', 'Bela Vista', '361', '', '01322-002', 'São Paulo', 'SP', 'Brasil', 361),
(264, 'Rua Snack SP', 'Mooca', '362', '', '03194-003', 'São Paulo', 'SP', 'Brasil', 362),
(265, 'Rua Salgados Express', 'Ipiranga', '363', '', '04294-004', 'São Paulo', 'SP', 'Brasil', 363),
(266, 'Rua Snacks Top', 'Vila Mariana', '364', '', '04094-005', 'São Paulo', 'SP', 'Brasil', 364),
(267, 'Rua Salgados Mais', 'Pinheiros', '365', '', '05494-006', 'São Paulo', 'SP', 'Brasil', 365),
(268, 'Rua Snacks Premium', 'Lapa', '366', '', '05094-007', 'São Paulo', 'SP', 'Brasil', 366),
(269, 'Rua Salgados União', 'Santana', '367', '', '02094-008', 'São Paulo', 'SP', 'Brasil', 367),
(270, 'Rua Snacks Master', 'Tatuapé', '368', '', '03394-009', 'São Paulo', 'SP', 'Brasil', 368),
(271, 'Rua Salgados Paulista', 'Centro', '369', '', '01094-010', 'São Paulo', 'SP', 'Brasil', 369),
(272, 'Rua Salgados Central', 'Mooca', '370', '', '03194-011', 'São Paulo', 'SP', 'Brasil', 370),
(273, 'Rua Snacks Mais', 'Ipiranga', '371', '', '04294-012', 'São Paulo', 'SP', 'Brasil', 371),
(274, 'Rua Salgados Delicatessen', 'Vila Mariana', '372', '', '04094-013', 'São Paulo', 'SP', 'Brasil', 372),
(275, 'Rua Snacks Central', 'Pinheiros', '373', '', '05494-014', 'São Paulo', 'SP', 'Brasil', 373),
(276, 'Rua Salgados Prime', 'Lapa', '374', '', '05094-015', 'São Paulo', 'SP', 'Brasil', 374),
(277, 'Rua Snacks Delícia', 'Santana', '375', '', '02094-016', 'São Paulo', 'SP', 'Brasil', 375),
(278, 'Rua Salgados Top', 'Tatuapé', '376', '', '03394-017', 'São Paulo', 'SP', 'Brasil', 376),
(279, 'Rua Snacks Comercial', 'Centro', '377', '', '01094-018', 'São Paulo', 'SP', 'Brasil', 377),
(280, 'Rua Salgados Master', 'Mooca', '378', '', '03194-019', 'São Paulo', 'SP', 'Brasil', 378),
(281, 'Rua Snacks Paulista', 'Ipiranga', '379', '', '04294-020', 'São Paulo', 'SP', 'Brasil', 379),
(282, 'Rua Naturais', 'Centro', '380', '', '01095-001', 'São Paulo', 'SP', 'Brasil', 380),
(283, 'Rua Orgânicos', 'Bela Vista', '381', '', '01323-002', 'São Paulo', 'SP', 'Brasil', 381),
(284, 'Rua Bio Produtos', 'Mooca', '382', '', '03195-003', 'São Paulo', 'SP', 'Brasil', 382),
(285, 'Rua Naturais & Cia', 'Ipiranga', '383', '', '04295-004', 'São Paulo', 'SP', 'Brasil', 383),
(286, 'Rua Orgânicos Premium', 'Vila Mariana', '384', '', '04095-005', 'São Paulo', 'SP', 'Brasil', 384),
(287, 'Rua Distribuidora Bio', 'Pinheiros', '385', '', '05495-006', 'São Paulo', 'SP', 'Brasil', 385),
(288, 'Rua Naturais Mais', 'Lapa', '386', '', '05095-007', 'São Paulo', 'SP', 'Brasil', 386),
(289, 'Rua Orgânicos Delícia', 'Santana', '387', '', '02095-008', 'São Paulo', 'SP', 'Brasil', 387),
(290, 'Rua Bio Central', 'Tatuapé', '388', '', '03395-009', 'São Paulo', 'SP', 'Brasil', 388),
(291, 'Rua Naturais Master', 'Centro', '389', '', '01095-010', 'São Paulo', 'SP', 'Brasil', 389),
(292, 'Rua Orgânicos Paulista', 'Mooca', '390', '', '03195-011', 'São Paulo', 'SP', 'Brasil', 390),
(293, 'Rua Naturais Central', 'Ipiranga', '391', '', '04295-012', 'São Paulo', 'SP', 'Brasil', 391),
(294, 'Rua Bio Delicatessen', 'Vila Mariana', '392', '', '04095-013', 'São Paulo', 'SP', 'Brasil', 392),
(295, 'Rua Naturais Prime', 'Pinheiros', '393', '', '05495-014', 'São Paulo', 'SP', 'Brasil', 393),
(296, 'Rua Orgânicos Top', 'Lapa', '394', '', '05095-015', 'São Paulo', 'SP', 'Brasil', 394),
(297, 'Rua Bio Mais', 'Santana', '395', '', '02095-016', 'São Paulo', 'SP', 'Brasil', 395),
(298, 'Rua Naturais Express', 'Tatuapé', '396', '', '03395-017', 'São Paulo', 'SP', 'Brasil', 396),
(299, 'Rua Orgânicos Comercial', 'Centro', '397', '', '01095-018', 'São Paulo', 'SP', 'Brasil', 397),
(300, 'Rua Bio Master', 'Mooca', '398', '', '03195-019', 'São Paulo', 'SP', 'Brasil', 398),
(301, 'Rua Naturais Paulista', 'Ipiranga', '399', '', '04295-020', 'São Paulo', 'SP', 'Brasil', 399),
(302, 'Rua Baby', 'Centro', '400', '', '01096-001', 'São Paulo', 'SP', 'Brasil', 400),
(303, 'Rua Kids', 'Bela Vista', '401', '', '01324-002', 'São Paulo', 'SP', 'Brasil', 401),
(304, 'Rua Mundo Infantil', 'Mooca', '402', '', '03196-003', 'São Paulo', 'SP', 'Brasil', 402),
(305, 'Rua Bebês & Cia', 'Ipiranga', '403', '', '04296-004', 'São Paulo', 'SP', 'Brasil', 403),
(306, 'Rua Baby Premium', 'Vila Mariana', '404', '', '04096-005', 'São Paulo', 'SP', 'Brasil', 404),
(307, 'Rua Kids Central', 'Pinheiros', '405', '', '05496-006', 'São Paulo', 'SP', 'Brasil', 405),
(308, 'Rua Mundo Baby', 'Lapa', '406', '', '05096-007', 'São Paulo', 'SP', 'Brasil', 406),
(309, 'Rua Kids Master', 'Santana', '407', '', '02096-008', 'São Paulo', 'SP', 'Brasil', 407),
(310, 'Rua Bebês Paulista', 'Tatuapé', '408', '', '03396-009', 'São Paulo', 'SP', 'Brasil', 408),
(311, 'Rua Baby Express', 'Centro', '409', '', '01096-010', 'São Paulo', 'SP', 'Brasil', 409),
(312, 'Rua Kids Delícia', 'Mooca', '410', '', '03196-011', 'São Paulo', 'SP', 'Brasil', 410),
(313, 'Rua Mundo Infantil Premium', 'Ipiranga', '411', '', '04296-012', 'São Paulo', 'SP', 'Brasil', 411),
(314, 'Rua Bebês Central', 'Vila Mariana', '412', '', '04096-013', 'São Paulo', 'SP', 'Brasil', 412),
(315, 'Rua Baby Prime', 'Pinheiros', '413', '', '05496-014', 'São Paulo', 'SP', 'Brasil', 413),
(316, 'Rua Kids Top', 'Lapa', '414', '', '05096-015', 'São Paulo', 'SP', 'Brasil', 414),
(317, 'Rua Bebês Mais', 'Santana', '415', '', '02096-016', 'São Paulo', 'SP', 'Brasil', 415),
(318, 'Rua Mundo Baby Express', 'Tatuapé', '416', '', '03396-017', 'São Paulo', 'SP', 'Brasil', 416),
(319, 'Rua Kids Comercial', 'Centro', '417', '', '01096-018', 'São Paulo', 'SP', 'Brasil', 417),
(320, 'Rua Bebês Master', 'Mooca', '418', '', '03196-019', 'São Paulo', 'SP', 'Brasil', 418),
(321, 'Rua Baby Paulista', 'Ipiranga', '419', '', '04296-020', 'São Paulo', 'SP', 'Brasil', 419),
(322, 'Rua Pet', 'Centro', '420', '', '01097-001', 'São Paulo', 'SP', 'Brasil', 420),
(323, 'Rua Pets', 'Bela Vista', '421', '', '01325-002', 'São Paulo', 'SP', 'Brasil', 421),
(324, 'Rua Pet Mania', 'Mooca', '422', '', '03197-003', 'São Paulo', 'SP', 'Brasil', 422),
(325, 'Rua Pet & Cia', 'Ipiranga', '423', '', '04297-004', 'São Paulo', 'SP', 'Brasil', 423),
(326, 'Rua Pet Premium', 'Vila Mariana', '424', '', '04097-005', 'São Paulo', 'SP', 'Brasil', 424),
(327, 'Rua Pet Central', 'Pinheiros', '425', '', '05497-006', 'São Paulo', 'SP', 'Brasil', 425),
(328, 'Rua Pet Master', 'Lapa', '426', '', '05097-007', 'São Paulo', 'SP', 'Brasil', 426),
(329, 'Rua Pet Paulista', 'Santana', '427', '', '02097-008', 'São Paulo', 'SP', 'Brasil', 427),
(330, 'Rua Pet Express', 'Tatuapé', '428', '', '03397-009', 'São Paulo', 'SP', 'Brasil', 428),
(331, 'Rua Pet Delícia', 'Centro', '429', '', '01097-010', 'São Paulo', 'SP', 'Brasil', 429),
(332, 'Rua Pet Top', 'Mooca', '430', '', '03197-011', 'São Paulo', 'SP', 'Brasil', 430),
(333, 'Rua Pet Mais', 'Ipiranga', '431', '', '04297-012', 'São Paulo', 'SP', 'Brasil', 431),
(334, 'Rua Pet Comercial', 'Vila Mariana', '432', '', '04097-013', 'São Paulo', 'SP', 'Brasil', 432),
(335, 'Rua Pet Delicatessen', 'Pinheiros', '433', '', '05497-014', 'São Paulo', 'SP', 'Brasil', 433),
(336, 'Rua Pet Central Premium', 'Lapa', '434', '', '05097-015', 'São Paulo', 'SP', 'Brasil', 434),
(337, 'Rua Pet Express Brasil', 'Santana', '435', '', '02097-016', 'São Paulo', 'SP', 'Brasil', 435),
(338, 'Rua Pet Master Premium', 'Tatuapé', '436', '', '03397-017', 'São Paulo', 'SP', 'Brasil', 436),
(339, 'Rua Pet Mais Brasil', 'Centro', '437', '', '01097-018', 'São Paulo', 'SP', 'Brasil', 437),
(340, 'Rua Pet Comercial Premium', 'Mooca', '438', '', '03197-019', 'São Paulo', 'SP', 'Brasil', 438),
(341, 'Rua Pet Paulista Premium', 'Ipiranga', '439', '', '04297-020', 'São Paulo', 'SP', 'Brasil', 439),
(342, 'Rua Casa', 'Centro', '440', '', '01098-001', 'São Paulo', 'SP', 'Brasil', 440),
(343, 'Rua Utilidades', 'Bela Vista', '441', '', '01326-002', 'São Paulo', 'SP', 'Brasil', 441),
(344, 'Rua Lar Central', 'Mooca', '442', '', '03198-003', 'São Paulo', 'SP', 'Brasil', 442),
(345, 'Rua Casa Premium', 'Ipiranga', '443', '', '04298-004', 'São Paulo', 'SP', 'Brasil', 443),
(346, 'Rua Lar SP', 'Vila Mariana', '444', '', '04098-005', 'São Paulo', 'SP', 'Brasil', 444),
(347, 'Rua Casa Master', 'Pinheiros', '445', '', '05498-006', 'São Paulo', 'SP', 'Brasil', 445),
(348, 'Rua Utilidades Mais', 'Lapa', '446', '', '05098-007', 'São Paulo', 'SP', 'Brasil', 446),
(349, 'Rua Lar Express', 'Santana', '447', '', '02098-008', 'São Paulo', 'SP', 'Brasil', 447),
(350, 'Rua Casa Delícia', 'Tatuapé', '448', '', '03398-009', 'São Paulo', 'SP', 'Brasil', 448),
(351, 'Rua Utilidades Paulista', 'Centro', '449', '', '01098-010', 'São Paulo', 'SP', 'Brasil', 449),
(352, 'Rua Casa Prime', 'Mooca', '450', '', '03198-011', 'São Paulo', 'SP', 'Brasil', 450),
(353, 'Rua Lar Top', 'Ipiranga', '451', '', '04298-012', 'São Paulo', 'SP', 'Brasil', 451),
(354, 'Rua Casa Central', 'Vila Mariana', '452', '', '04098-013', 'São Paulo', 'SP', 'Brasil', 452),
(355, 'Rua Utilidades Delicatessen', 'Pinheiros', '453', '', '05498-014', 'São Paulo', 'SP', 'Brasil', 453),
(356, 'Rua Casa Mais', 'Lapa', '454', '', '05098-015', 'São Paulo', 'SP', 'Brasil', 454),
(357, 'Rua Lar Comercial', 'Santana', '455', '', '02098-016', 'São Paulo', 'SP', 'Brasil', 455),
(358, 'Rua Casa Express', 'Tatuapé', '456', '', '03398-017', 'São Paulo', 'SP', 'Brasil', 456),
(359, 'Rua Utilidades Master', 'Centro', '457', '', '01098-018', 'São Paulo', 'SP', 'Brasil', 457),
(360, 'Rua Lar Paulista Premium', 'Mooca', '458', '', '03198-019', 'São Paulo', 'SP', 'Brasil', 458),
(361, 'Rua Casa Comercial', 'Ipiranga', '459', '', '04298-020', 'São Paulo', 'SP', 'Brasil', 459),
(362, 'Rua Gourmet Congelados', 'Centro', '460', '', '01100-001', 'São Paulo', 'SP', 'Brasil', 460),
(363, 'Rua Premium Prontos', 'Bela Vista', '461', '', '01330-002', 'São Paulo', 'SP', 'Brasil', 461),
(364, 'Rua Express Frozen', 'Mooca', '462', '', '03200-003', 'São Paulo', 'SP', 'Brasil', 462),
(365, 'Rua Delícia Congelados & Cia', 'Ipiranga', '463', '', '04300-004', 'São Paulo', 'SP', 'Brasil', 463),
(366, 'Rua Premium Prontos Brasil', 'Vila Mariana', '464', '', '04100-005', 'São Paulo', 'SP', 'Brasil', 464),
(367, 'Rua Central Frozen SP', 'Pinheiros', '465', '', '05500-006', 'São Paulo', 'SP', 'Brasil', 465),
(368, 'Rua Master Congelados Gourmet', 'Lapa', '466', '', '05100-007', 'São Paulo', 'SP', 'Brasil', 466),
(369, 'Rua Express Prontos Paulista', 'Santana', '467', '', '02100-008', 'São Paulo', 'SP', 'Brasil', 467),
(370, 'Rua Express Frozen Brasil', 'Tatuapé', '468', '', '03400-009', 'São Paulo', 'SP', 'Brasil', 468),
(371, 'Rua Delícia Congelados SP', 'Centro', '469', '', '01100-010', 'São Paulo', 'SP', 'Brasil', 469),
(372, 'Rua Top Prontos Gourmet', 'Mooca', '470', '', '03200-011', 'São Paulo', 'SP', 'Brasil', 470),
(373, 'Rua Mais Frozen Brasil', 'Ipiranga', '471', '', '04300-012', 'São Paulo', 'SP', 'Brasil', 471),
(374, 'Rua Delicatessen Congelados SP', 'Vila Mariana', '472', '', '04100-013', 'São Paulo', 'SP', 'Brasil', 472),
(375, 'Rua Central Express Prontos', 'Pinheiros', '473', '', '05500-014', 'São Paulo', 'SP', 'Brasil', 473),
(376, 'Rua Prime Frozen Brasil', 'Lapa', '474', '', '05100-015', 'São Paulo', 'SP', 'Brasil', 474),
(377, 'Rua Express Congelados Gourmet', 'Santana', '475', '', '02100-016', 'São Paulo', 'SP', 'Brasil', 475),
(378, 'Rua Master Prontos SP', 'Tatuapé', '476', '', '03400-017', 'São Paulo', 'SP', 'Brasil', 476),
(379, 'Rua Gourmet Frozen Paulista', 'Centro', '477', '', '01100-018', 'São Paulo', 'SP', 'Brasil', 477),
(380, 'Rua Comercial Express Congelados', 'Mooca', '478', '', '03200-019', 'São Paulo', 'SP', 'Brasil', 478),
(381, 'Rua Delícia Gourmet Prontos', 'Ipiranga', '479', '', '04300-020', 'São Paulo', 'SP', 'Brasil', 479),
(382, 'Rua Gourmet Importados', 'Centro', '480', '', '010101-001', 'São Paulo', 'SP', 'Brasil', 480),
(383, 'Rua World Imports Premium', 'Bela Vista', '481', '', '01329-002', 'São Paulo', 'SP', 'Brasil', 481),
(384, 'Rua Global Products Express', 'Mooca', '482', '', '03201-003', 'São Paulo', 'SP', 'Brasil', 482),
(385, 'Rua Importados & Cia Delícia', 'Ipiranga', '483', '', '04301-004', 'São Paulo', 'SP', 'Brasil', 483),
(386, 'Rua Premium Imports Brasil', 'Vila Mariana', '484', '', '04101-005', 'São Paulo', 'SP', 'Brasil', 484),
(387, 'Rua Global Central SP', 'Pinheiros', '485', '', '05501-006', 'São Paulo', 'SP', 'Brasil', 485),
(388, 'Rua Importados Master Gourmet', 'Lapa', '486', '', '05101-007', 'São Paulo', 'SP', 'Brasil', 486),
(389, 'Rua Imports Paulista Express', 'Santana', '487', '', '02101-008', 'São Paulo', 'SP', 'Brasil', 487),
(390, 'Rua Express Imports Brasil', 'Tatuapé', '488', '', '03401-009', 'São Paulo', 'SP', 'Brasil', 488),
(391, 'Rua Importados Delícia SP', 'Centro', '489', '', '010101-010', 'São Paulo', 'SP', 'Brasil', 489),
(392, 'Rua Top Imports Brasil Gourmet', 'Mooca', '490', '', '03201-011', 'São Paulo', 'SP', 'Brasil', 490),
(393, 'Rua Global Mais Express SP', 'Ipiranga', '491', '', '04301-012', 'São Paulo', 'SP', 'Brasil', 491),
(394, 'Rua Importados Delicatessen SP', 'Vila Mariana', '492', '', '04101-013', 'São Paulo', 'SP', 'Brasil', 492),
(395, 'Rua Central Imports Brasil', 'Pinheiros', '493', '', '05501-014', 'São Paulo', 'SP', 'Brasil', 493),
(396, 'Rua Premium Imports Express SP', 'Lapa', '494', '', '05101-015', 'São Paulo', 'SP', 'Brasil', 494),
(397, 'Rua Express Global Imports', 'Santana', '495', '', '02101-016', 'São Paulo', 'SP', 'Brasil', 495),
(398, 'Rua Master Imports Brasil Gourmet', 'Tatuapé', '496', '', '03401-017', 'São Paulo', 'SP', 'Brasil', 496),
(399, 'Rua Imports Mais Brasil Premium', 'Centro', '497', '', '010101-018', 'São Paulo', 'SP', 'Brasil', 497),
(400, 'Rua Comercial Imports SP Gourmet', 'Mooca', '498', '', '03201-019', 'São Paulo', 'SP', 'Brasil', 498),
(401, 'Rua Imports Paulista Premium Express', 'Ipiranga', '499', '', '04301-020', 'São Paulo', 'SP', 'Brasil', 499),
(402, 'Centro', 'Moreira', '100', 'Ao lado do shops', '12345-250', 'Pinda', 'SP', 'Brasil', 502),
(403, 'Rua Thiago', 'Bairro Thiago', '43', 'Thiago', '12444-355', 'Pinda', 'SP', 'Brasil', 503),
(404, 'centro', 'Centro', '45', 'casa', '21212-121', 'Pinda', 'SP', 'Brasil', 504);

-- --------------------------------------------------------

--
-- Estrutura para tabela `endereco_funcionario`
--

CREATE TABLE `endereco_funcionario` (
  `id_endereco_funcionario` int(11) NOT NULL,
  `pais_funcionario` varchar(20) NOT NULL,
  `estado_funcionario` varchar(20) NOT NULL,
  `cidade_funcionario` varchar(20) NOT NULL,
  `bairro_funcionario` varchar(20) NOT NULL,
  `rua_funcionario` varchar(20) NOT NULL,
  `numero_funcionario` varchar(10) NOT NULL,
  `complemento_funcionario` varchar(20) DEFAULT NULL,
  `id_funcionario` int(11) NOT NULL,
  `cep_funcionario` varchar(18) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `endereco_funcionario`
--

INSERT INTO `endereco_funcionario` (`id_endereco_funcionario`, `pais_funcionario`, `estado_funcionario`, `cidade_funcionario`, `bairro_funcionario`, `rua_funcionario`, `numero_funcionario`, `complemento_funcionario`, `id_funcionario`, `cep_funcionario`) VALUES
(1, 'Brasil', 'SP', 'São Paulo', 'Vila Mariana', 'Rua Domingos de Mora', '1234', 'Apto 56', 1, '04010-200'),
(2, 'Brasil', 'RJ', 'Rio de Janeiro', 'Copacabana', 'Avenida Atlântica', '987', 'Bloco B', 2, '22021-001'),
(3, 'Brasil', 'SP', 'São Paulo', 'Pinheiros', 'Rua Santos Silva', '754', 'Apto:24', 11, '12500000'),
(4, 'Brasil', 'SP', 'São Paulo', 'Pinheiros', 'Rua Santos Silva', '754', 'Apto:24', 14, '12500000');

-- --------------------------------------------------------

--
-- Estrutura para tabela `estoque`
--

CREATE TABLE `estoque` (
  `id_estoque` int(11) NOT NULL,
  `id_produto` int(11) NOT NULL,
  `n_lote` varchar(50) NOT NULL,
  `data_validade` date NOT NULL,
  `qtd_produto` int(11) NOT NULL,
  `status` varchar(20) NOT NULL,
  `local_estoque` varchar(50) NOT NULL,
  `data_entrada` date NOT NULL,
  `id_fornecedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `forma_pagamento`
--

CREATE TABLE `forma_pagamento` (
  `id_forma_pagamento` int(11) NOT NULL,
  `tipo_pagamento` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `forma_pagamento`
--

INSERT INTO `forma_pagamento` (`id_forma_pagamento`, `tipo_pagamento`) VALUES
(1, 'PIX'),
(2, 'Cartão de Crédito'),
(3, 'Cartão de Débito'),
(4, 'Dinheiro');

-- --------------------------------------------------------

--
-- Estrutura para tabela `fornecedor`
--

CREATE TABLE `fornecedor` (
  `id_fornecedor` int(11) NOT NULL,
  `nome_fornecedor` varchar(50) NOT NULL,
  `cnpj_fornecedor` varchar(20) NOT NULL,
  `email_fornecedor` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `fornecedor`
--

INSERT INTO `fornecedor` (`id_fornecedor`, `nome_fornecedor`, `cnpj_fornecedor`, `email_fornecedor`) VALUES
(1, 'Tech Suprimentos LTDA', '12.345.678/0001-90', 'contato@techsuprimentos.com'),
(100, 'Limpeza Brilho Sul Ltda', '12.345.678/0001-01', 'contato@brilhosul.com.br'),
(101, 'Higiene Total Distribuidora', '23.456.789/0001-02', 'vendas@higienetotal.com.br'),
(102, 'CleanMax Produtos', '34.567.890/0001-03', 'atendimento@cleanmax.com.br'),
(103, 'UltraClean Brasil', '45.678.901/0001-04', 'contato@ultraclean.com.br'),
(104, 'LimpLar Distribuidora', '56.789.012/0001-05', 'vendas@limplar.com.br'),
(105, 'EcoLimpeza Ltda', '67.890.123/0001-06', 'eco@limpeza.com.br'),
(106, 'TopClean Soluções', '78.901.234/0001-07', 'contato@topclean.com.br'),
(107, 'Higiprodutos SP', '89.012.345/0001-08', 'vendas@higisp.com.br'),
(108, 'LimpaFácil Brasil', '90.123.456/0001-09', 'contato@limpafacil.com.br'),
(109, 'Brilho Forte Produtos', '11.234.567/0001-10', 'vendas@brilhoforte.com.br'),
(110, 'SuperClean Atacado', '22.345.678/0001-11', 'atendimento@superclean.com.br'),
(111, 'MaxHigiene Ltda', '33.456.789/0001-12', 'contato@maxhigiene.com.br'),
(112, 'Prime Limpeza', '44.567.890/0001-13', 'vendas@primelimpeza.com.br'),
(113, 'LimpMais Distribuidora', '55.678.901/0001-14', 'contato@limpmais.com.br'),
(114, 'Casa Limpa Fornecedor', '66.789.012/0001-15', 'vendas@casalimpa.com.br'),
(115, 'TotalClean Produtos', '77.890.123/0001-16', 'contato@totalclean.com.br'),
(116, 'Higiene Forte Ltda', '88.901.234/0001-17', 'vendas@higieneforte.com.br'),
(117, 'EcoClean Brasil', '99.012.345/0001-18', 'contato@ecoclean.com.br'),
(118, 'Distribuidora Limpeza SP', '10.123.456/0001-19', 'vendas@dlsp.com.br'),
(119, 'Limpeza Rápida Ltda', '21.234.567/0001-20', 'contato@limpezarapida.com.br'),
(120, 'Alimentos Boa Mesa Ltda', '31.245.678/0001-21', 'contato@boamesa.com.br'),
(121, 'Distribuidora Sabor Real', '42.356.789/0001-22', 'vendas@saborreal.com.br'),
(122, 'Alimentos Vida Nova', '53.467.890/0001-23', 'contato@vidanova.com.br'),
(123, 'Comercial NutriMais', '64.578.901/0001-24', 'vendas@nutrimais.com.br'),
(124, 'Brasil Food Atacado', '75.689.012/0001-25', 'contato@brasilfood.com.br'),
(125, 'Alimentos União Sul', '86.790.123/0001-26', 'vendas@uniaosul.com.br'),
(126, 'Distribuidora Sabor Caseiro', '97.801.234/0001-27', 'contato@saborcaseiro.com.br'),
(127, 'Mega Alimentos SP', '18.912.345/0001-28', 'vendas@megaalimentos.com.br'),
(128, 'Prime Foods Brasil', '29.023.456/0001-29', 'contato@primefoods.com.br'),
(129, 'Alimentos Ponto Certo', '30.134.567/0001-30', 'vendas@pontocerto.com.br'),
(130, 'Distribuidora Alimentar', '41.245.678/0001-31', 'contato@alimentar.com.br'),
(131, 'Sabor & Vida Ltda', '52.356.789/0001-32', 'vendas@saborevida.com.br'),
(132, 'Comercial Bom Gosto', '63.467.890/0001-33', 'contato@bomgosto.com.br'),
(133, 'Alimentos São Paulo', '74.578.901/0001-34', 'vendas@alimentosp.com.br'),
(134, 'Distribuidora NutriBrasil', '85.689.012/0001-35', 'contato@nutribra.com.br'),
(135, 'Central dos Alimentos', '96.790.123/0001-36', 'vendas@centralalimentos.com.br'),
(136, 'Alimentos Sabor Brasil', '17.801.234/0001-37', 'contato@saborbrasil.com.br'),
(137, 'Top Alimentos Ltda', '28.912.345/0001-38', 'vendas@topalimentos.com.br'),
(138, 'Alimenta Mais Brasil', '39.023.456/0001-39', 'contato@alimentamais.com.br'),
(139, 'Distribuidora Aliança', '40.134.567/0001-40', 'vendas@alianca.com.br'),
(140, 'Bebidas Brasil Ltda', '11.111.111/0001-41', 'contato@bebidasbrasil.com.br'),
(141, 'Distribuidora Água Viva', '11.111.112/0001-42', 'contato@aguaviva.com.br'),
(142, 'Refrescos Tropicais', '11.111.113/0001-43', 'contato@tropicais.com.br'),
(143, 'Bebidas Geladas SP', '11.111.114/0001-44', 'contato@geladas.com.br'),
(144, 'Suco Natural Brasil', '11.111.115/0001-45', 'contato@sucos.com.br'),
(145, 'Central das Bebidas', '11.111.116/0001-46', 'contato@centralbebidas.com.br'),
(146, 'Distribuidora Refrescar', '11.111.117/0001-47', 'contato@refrescar.com.br'),
(147, 'Bebidas Premium', '11.111.118/0001-48', 'contato@premium.com.br'),
(148, 'Água Mineral Pura', '11.111.119/0001-49', 'contato@aguapura.com.br'),
(149, 'Bebidas Rápidas', '11.111.120/0001-50', 'contato@rapidas.com.br'),
(150, 'Distribuidora Bebidas SP', '11.111.121/0001-51', 'contato@bebidassp.com.br'),
(151, 'Refrigerantes Brasil', '11.111.122/0001-52', 'contato@refri.com.br'),
(152, 'Bebidas Top', '11.111.123/0001-53', 'contato@bebidastop.com.br'),
(153, 'Sucos Naturais Ltda', '11.111.124/0001-54', 'contato@sucosnat.com.br'),
(154, 'Distribuidora Drink', '11.111.125/0001-55', 'contato@drink.com.br'),
(155, 'Bebidas Fresh', '11.111.126/0001-56', 'contato@fresh.com.br'),
(156, 'Água & Cia', '11.111.127/0001-57', 'contato@aguaecia.com.br'),
(157, 'Bebidas Express', '11.111.128/0001-58', 'contato@express.com.br'),
(158, 'Distribuidora RefriMax', '11.111.129/0001-59', 'contato@refrimax.com.br'),
(159, 'Bebidas União', '11.111.130/0001-60', 'contato@uniao.com.br'),
(160, 'Higiene Vida Ltda', '22.111.111/0001-61', 'contato@higienevida.com.br'),
(161, 'Beleza Natural Distribuidora', '22.111.112/0001-62', 'contato@belezanatural.com.br'),
(162, 'Cuidados Pessoais Brasil', '22.111.113/0001-63', 'contato@cuidados.com.br'),
(163, 'Higiene Total SP', '22.111.114/0001-64', 'contato@higienetotalsp.com.br'),
(164, 'Bem Estar Produtos', '22.111.115/0001-65', 'contato@bemestar.com.br'),
(165, 'Distribuidora Corpo & Vida', '22.111.116/0001-66', 'contato@corpoevida.com.br'),
(166, 'Higiene Premium', '22.111.117/0001-67', 'contato@premiumhigiene.com.br'),
(167, 'Beleza Pura Ltda', '22.111.118/0001-68', 'contato@belezapura.com.br'),
(168, 'Cuidados Essenciais', '22.111.119/0001-69', 'contato@essenciais.com.br'),
(169, 'Higiene Express', '22.111.120/0001-70', 'contato@higieneexpress.com.br'),
(170, 'Distribuidora Bem Viver', '22.111.121/0001-71', 'contato@bemviver.com.br'),
(171, 'Produtos de Higiene Brasil', '22.111.122/0001-72', 'contato@higienebrasil.com.br'),
(172, 'Beleza & Saúde Ltda', '22.111.123/0001-73', 'contato@belezasaude.com.br'),
(173, 'Higiene Forte', '22.111.124/0001-74', 'contato@higieneforte.com.br'),
(174, 'Distribuidora Vida Limpa', '22.111.125/0001-75', 'contato@vidalimpa.com.br'),
(175, 'Cuidados Naturais', '22.111.126/0001-76', 'contato@naturais.com.br'),
(176, 'Higiene Plus', '22.111.127/0001-77', 'contato@higieneplus.com.br'),
(177, 'Beleza Brasil', '22.111.128/0001-78', 'contato@belezabrasil.com.br'),
(178, 'Distribuidora Corpo Limpo', '22.111.129/0001-79', 'contato@corpolimpo.com.br'),
(179, 'Higiene Máxima', '22.111.130/0001-80', 'contato@higienemaxima.com.br'),
(180, 'Frios São Paulo Ltda', '33.111.111/0001-81', 'contato@friossp.com.br'),
(181, 'Distribuidora Frios Brasil', '33.111.112/0001-82', 'contato@friosbrasil.com.br'),
(182, 'Frios & Cia', '33.111.113/0001-83', 'contato@frioscia.com.br'),
(183, 'Central de Frios', '33.111.114/0001-84', 'contato@centralfrios.com.br'),
(184, 'Frios Premium', '33.111.115/0001-85', 'contato@friospremium.com.br'),
(185, 'Distribuidora Sabor Frio', '33.111.116/0001-86', 'contato@saborfrio.com.br'),
(186, 'Frios Delícia', '33.111.117/0001-87', 'contato@friosdelicia.com.br'),
(187, 'Frios Express', '33.111.118/0001-88', 'contato@friosexpress.com.br'),
(188, 'Frios Top', '33.111.119/0001-89', 'contato@friostop.com.br'),
(189, 'Distribuidora Frios SP', '33.111.120/0001-90', 'contato@friosspdist.com.br'),
(190, 'Frios União', '33.111.121/0001-91', 'contato@friosuniao.com.br'),
(191, 'Frios Mais', '33.111.122/0001-92', 'contato@friosmais.com.br'),
(192, 'Frios Brasil Sul', '33.111.123/0001-93', 'contato@friosbrasilsul.com.br'),
(193, 'Frios Sabor & Arte', '33.111.124/0001-94', 'contato@saborarte.com.br'),
(194, 'Frios Central SP', '33.111.125/0001-95', 'contato@centralsp.com.br'),
(195, 'Distribuidora Frios Prime', '33.111.126/0001-96', 'contato@friosprime.com.br'),
(196, 'Frios Delicatessen', '33.111.127/0001-97', 'contato@delicatessen.com.br'),
(197, 'Frios Master', '33.111.128/0001-98', 'contato@friosmaster.com.br'),
(198, 'Frios Comercial', '33.111.129/0001-99', 'contato@frioscomercial.com.br'),
(199, 'Frios Paulista', '33.111.130/0001-00', 'contato@friospaulista.com.br'),
(200, 'Padaria Fornecedora Pão Nobre', '44.111.111/0001-01', 'contato@paonobre.com.br'),
(201, 'Distribuidora Trigo & Cia', '44.111.112/0001-02', 'contato@trigoecia.com.br'),
(202, 'Panificação Brasil Ltda', '44.111.113/0001-03', 'contato@panificacaobrasil.com.br'),
(203, 'Central de Pães SP', '44.111.114/0001-04', 'contato@centralpaes.com.br'),
(204, 'Pães & Massas Fornecedor', '44.111.115/0001-05', 'contato@paesmassas.com.br'),
(205, 'Distribuidora Pão Quente', '44.111.116/0001-06', 'contato@paoquente.com.br'),
(206, 'Padaria Industrial Brasil', '44.111.117/0001-07', 'contato@padindustrial.com.br'),
(207, 'Pães Premium Ltda', '44.111.118/0001-08', 'contato@paespremium.com.br'),
(208, 'Panificadora União', '44.111.119/0001-09', 'contato@uniaopan.com.br'),
(209, 'Distribuidora Massa Fina', '44.111.120/0001-10', 'contato@massafina.com.br'),
(210, 'Pães Express', '44.111.121/0001-11', 'contato@paesexpress.com.br'),
(211, 'Padaria Central SP', '44.111.122/0001-12', 'contato@padariacentral.com.br'),
(212, 'Pão & Arte Ltda', '44.111.123/0001-13', 'contato@paoearte.com.br'),
(213, 'Distribuidora Trigo Forte', '44.111.124/0001-14', 'contato@trigoforte.com.br'),
(214, 'Padaria Sabor Real', '44.111.125/0001-15', 'contato@saborreal.com.br'),
(215, 'Pães Delícia', '44.111.126/0001-16', 'contato@paesdelicia.com.br'),
(216, 'Panificação Paulista', '44.111.127/0001-17', 'contato@paulista.com.br'),
(217, 'Distribuidora Pão Mais', '44.111.128/0001-18', 'contato@paomais.com.br'),
(218, 'Pães & Cia Brasil', '44.111.129/0001-19', 'contato@paescia.com.br'),
(219, 'Padaria Top Sabor', '44.111.130/0001-20', 'contato@topsabor.com.br'),
(220, 'Hortifruti Campos', '55.111.111/0001-21', 'contato@hortifruticampos.com.br'),
(221, 'Verde Sabor Distribuidora', '55.111.112/0001-22', 'contato@verdesabor.com.br'),
(222, 'Frutas Tropicais Ltda', '55.111.113/0001-23', 'contato@frutastropicais.com.br'),
(223, 'Verduras da Horta', '55.111.114/0001-24', 'contato@verdurasdhorta.com.br'),
(224, 'Hortifruti Brasil SP', '55.111.115/0001-25', 'contato@hortibrasilsp.com.br'),
(225, 'Distribuidora Jardim Verde', '55.111.116/0001-26', 'contato@jardimverde.com.br'),
(226, 'Frutas do Vale Ltda', '55.111.117/0001-27', 'contato@frutasdovale.com.br'),
(227, 'Verduras Express SP', '55.111.118/0001-28', 'contato@verdurasexpress.com.br'),
(228, 'HortiPremium', '55.111.119/0001-29', 'contato@hortipremium.com.br'),
(229, 'Verde União Distribuidora', '55.111.120/0001-30', 'contato@verdeuniao.com.br'),
(230, 'Frutas Selecionadas SP', '55.111.121/0001-31', 'contato@frutasselecionadas.com.br'),
(231, 'Verduras Naturais', '55.111.122/0001-32', 'contato@verdurasnaturais.com.br'),
(232, 'Hortifruti União SP', '55.111.123/0001-33', 'contato@hortiuniao.com.br'),
(233, 'Distribuidora Verde Campo', '55.111.124/0001-34', 'contato@verdecampo.com.br'),
(234, 'Frutas & Cia Ltda', '55.111.125/0001-35', 'contato@frutascia.com.br'),
(235, 'Verduras do Interior', '55.111.126/0001-36', 'contato@verdurasinterior.com.br'),
(236, 'HortiBrasil', '55.111.127/0001-37', 'contato@hortibrasil.com.br'),
(237, 'Distribuidora Campo Verde SP', '55.111.128/0001-38', 'contato@campoverdesp.com.br'),
(238, 'Frutas do Sul Ltda', '55.111.129/0001-39', 'contato@frutasdossul.com.br'),
(239, 'Hortifruti Top SP', '55.111.130/0001-40', 'contato@hortitopsp.com.br'),
(240, 'Carnes Sul Ltda', '66.111.111/0001-41', 'contato@carnessul.com.br'),
(241, 'Distribuidora Boi Nobre', '66.111.112/0001-42', 'contato@boinobre.com.br'),
(242, 'Carnes do Campo', '66.111.113/0001-43', 'contato@carnescampo.com.br'),
(243, 'Frigorífico União SP', '66.111.114/0001-44', 'contato@frigouniao.com.br'),
(244, 'Carnes Premium Brasil', '66.111.115/0001-45', 'contato@carnespremium.com.br'),
(245, 'Distribuidora Bovina SP', '66.111.116/0001-46', 'contato@bovinasp.com.br'),
(246, 'Carnes Delícia SP', '66.111.117/0001-47', 'contato@carnesdelicia.com.br'),
(247, 'Carnes Express Brasil', '66.111.118/0001-48', 'contato@carnesexpress.com.br'),
(248, 'Carnes Top SP', '66.111.119/0001-49', 'contato@carnestop.com.br'),
(249, 'Distribuidora Carnes Paulista', '66.111.120/0001-50', 'contato@carnespaulista.com.br'),
(250, 'Carnes União Brasil', '66.111.121/0001-51', 'contato@carnesuniao.com.br'),
(251, 'Carnes Mais SP', '66.111.122/0001-52', 'contato@carnesmais.com.br'),
(252, 'Carnes Sul Premium', '66.111.123/0001-53', 'contato@carnessulpremium.com.br'),
(253, 'Carnes Arte e Sabor', '66.111.124/0001-54', 'contato@carnesarte.com.br'),
(254, 'Central de Carnes Brasil', '66.111.125/0001-55', 'contato@centralcarnes.com.br'),
(255, 'Distribuidora Carnes Prime SP', '66.111.126/0001-56', 'contato@carnesprime.com.br'),
(256, 'Carnes Delicatessen SP', '66.111.127/0001-57', 'contato@carnesdelicatessen.com.br'),
(257, 'Carnes Master Brasil', '66.111.128/0001-58', 'contato@carnesmaster.com.br'),
(258, 'Carnes Comercial SP', '66.111.129/0001-59', 'contato@carnescomercial.com.br'),
(259, 'Carnes Paulista Premium', '66.111.130/0001-60', 'contato@carnespaulistapremium.com.br'),
(260, 'Peixaria Atlântico', '77.111.111/0001-61', 'contato@peixariaatlantico.com.br'),
(261, 'Distribuidora Marinha SP', '77.111.112/0001-62', 'contato@marinhasp.com.br'),
(262, 'Peixes & Cia', '77.111.113/0001-63', 'contato@peixescia.com.br'),
(263, 'Central de Frutos do Mar', '77.111.114/0001-64', 'contato@centralfrutosmar.com.br'),
(264, 'Mariscos Premium', '77.111.115/0001-65', 'contato@mariscospremium.com.br'),
(265, 'Distribuidora Oceano', '77.111.116/0001-66', 'contato@distribuidoracoceano.com.br'),
(266, 'Peixes Delícia', '77.111.117/0001-67', 'contato@peixesdelicia.com.br'),
(267, 'Frutos do Mar Express', '77.111.118/0001-68', 'contato@frutosmarexpress.com.br'),
(268, 'Peixes Top', '77.111.119/0001-69', 'contato@peixestop.com.br'),
(269, 'Distribuidora Mar SP', '77.111.120/0001-70', 'contato@marsp.com.br'),
(270, 'Peixes União', '77.111.121/0001-71', 'contato@peixesuniao.com.br'),
(271, 'Peixes Mais', '77.111.122/0001-72', 'contato@peixesmais.com.br'),
(272, 'Oceano Sul', '77.111.123/0001-73', 'contato@oceanosul.com.br'),
(273, 'Sabor do Mar', '77.111.124/0001-74', 'contato@sabordomar.com.br'),
(274, 'Central Marinha SP', '77.111.125/0001-75', 'contato@centralmarinha.com.br'),
(275, 'Distribuidora Mar Prime', '77.111.126/0001-76', 'contato@marprime.com.br'),
(276, 'Peixes Delicatessen', '77.111.127/0001-77', 'contato@peixesdelicatessen.com.br'),
(277, 'Peixes Master', '77.111.128/0001-78', 'contato@peixesmaster.com.br'),
(278, 'Peixes Comercial', '77.111.129/0001-79', 'contato@peixescomercial.com.br'),
(279, 'Peixes Paulista', '77.111.130/0001-80', 'contato@peixespaulista.com.br'),
(280, 'Laticínios Campo Belo', '88.111.111/0001-81', 'contato@laticinioscampobelo.com.br'),
(281, 'Queijos São Jorge', '88.111.112/0001-82', 'contato@queijossaorge.com.br'),
(282, 'Leite Fresco SP', '88.111.113/0001-83', 'contato@leitefresco.com.br'),
(283, 'Laticínios Delícia Brasil', '88.111.114/0001-84', 'contato@laticiniosdelicia.com.br'),
(284, 'Queijos Premium SP', '88.111.115/0001-85', 'contato@queijospremium.com.br'),
(285, 'Laticínios União SP', '88.111.116/0001-86', 'contato@laticiniosuniao.com.br'),
(286, 'Leite do Campo', '88.111.117/0001-87', 'contato@leitdocampo.com.br'),
(287, 'Queijos Delicatessen', '88.111.118/0001-88', 'contato@queijosdelicatessen.com.br'),
(288, 'Laticínios Master SP', '88.111.119/0001-89', 'contato@laticiniosmaster.com.br'),
(289, 'Leite e Cia', '88.111.120/0001-90', 'contato@leiteeacia.com.br'),
(290, 'Queijaria Paulista', '88.111.121/0001-91', 'contato@queijariapaulista.com.br'),
(291, 'Laticínios Sabor Real', '88.111.122/0001-92', 'contato@laticiniossaborreal.com.br'),
(292, 'Leite Natural SP', '88.111.123/0001-93', 'contato@leitenaturalsp.com.br'),
(293, 'Queijos Artesanais Brasil', '88.111.124/0001-94', 'contato@queijosartesanais.com.br'),
(294, 'Laticínios Central SP', '88.111.125/0001-95', 'contato@laticinioscentral.com.br'),
(295, 'Distribuidora Leite Prime', '88.111.126/0001-96', 'contato@leiteprime.com.br'),
(296, 'Queijos & Delícias', '88.111.127/0001-97', 'contato@queijosedelicias.com.br'),
(297, 'Laticínios Top Brasil', '88.111.128/0001-98', 'contato@laticiniostop.com.br'),
(298, 'Leite Comercial SP', '88.111.129/0001-99', 'contato@leitecomercial.com.br'),
(299, 'Laticínios Paulista Premium', '88.111.130/0001-00', 'contato@laticiniospaulistapremium.com.br'),
(300, 'Congelados Brasil', '99.111.111/0001-01', 'contato@congeladosbrasil.com.br'),
(301, 'Distribuidora Gelo SP', '99.111.112/0001-02', 'contato@geloesp.com.br'),
(302, 'Freezer Express', '99.111.113/0001-03', 'contato@freezerexpress.com.br'),
(303, 'Congelados do Campo', '99.111.114/0001-04', 'contato@congeladosdocampo.com.br'),
(304, 'Gelados Premium', '99.111.115/0001-05', 'contato@geladospremium.com.br'),
(305, 'Distribuidora Frost SP', '99.111.116/0001-06', 'contato@frostsp.com.br'),
(306, 'Freezer Mais', '99.111.117/0001-07', 'contato@freezermais.com.br'),
(307, 'Congelados Express SP', '99.111.118/0001-08', 'contato@congeladosexpress.com.br'),
(308, 'Gelados Top', '99.111.119/0001-09', 'contato@geladostop.com.br'),
(309, 'Distribuidora Freezer Brasil', '99.111.120/0001-10', 'contato@freezerbrasil.com.br'),
(310, 'Congelados União', '99.111.121/0001-11', 'contato@congeladosuniao.com.br'),
(311, 'Freezer Mais SP', '99.111.122/0001-12', 'contato@freezermaissp.com.br'),
(312, 'Congelados Sul', '99.111.123/0001-13', 'contato@congeladosul.com.br'),
(313, 'Gelados Sabor', '99.111.124/0001-14', 'contato@geladossabor.com.br'),
(314, 'Central de Congelados SP', '99.111.125/0001-15', 'contato@centralcongelados.com.br'),
(315, 'Distribuidora Frost Premium', '99.111.126/0001-16', 'contato@frostpremium.com.br'),
(316, 'Congelados Delicatessen', '99.111.127/0001-17', 'contato@congeladosdelicatessen.com.br'),
(317, 'Freezer Master', '99.111.128/0001-18', 'contato@freezermaster.com.br'),
(318, 'Congelados Comercial', '99.111.129/0001-19', 'contato@congeladoscomercial.com.br'),
(319, 'Congelados Paulista', '99.111.130/0001-20', 'contato@congeladospaulista.com.br'),
(320, 'Grãos Brasil', '11.211.111/0001-21', 'contato@graosbrasil.com.br'),
(321, 'Massas Delícia', '11.211.112/0001-22', 'contato@massasdelicia.com.br'),
(322, 'Grãos & Cia', '11.211.113/0001-23', 'contato@graosecia.com.br'),
(323, 'Central de Massas SP', '11.211.114/0001-24', 'contato@centralmassas.com.br'),
(324, 'Distribuidora Grãos Premium', '11.211.115/0001-25', 'contato@graospremium.com.br'),
(325, 'Massas Express SP', '11.211.116/0001-26', 'contato@massasexpress.com.br'),
(326, 'Grãos União', '11.211.117/0001-27', 'contato@graosuniao.com.br'),
(327, 'Massas Mais SP', '11.211.118/0001-28', 'contato@massasmais.com.br'),
(328, 'Grãos Sabor', '11.211.119/0001-29', 'contato@graossabor.com.br'),
(329, 'Central Grãos SP', '11.211.120/0001-30', 'contato@centralgraos.com.br'),
(330, 'Distribuidora Massas Prime', '11.211.121/0001-31', 'contato@massasprime.com.br'),
(331, 'Grãos Delicatessen', '11.211.122/0001-32', 'contato@graosdelicatessen.com.br'),
(332, 'Massas Top Brasil', '11.211.123/0001-33', 'contato@massastop.com.br'),
(333, 'Grãos Master SP', '11.211.124/0001-34', 'contato@graosmaster.com.br'),
(334, 'Massas Comercial', '11.211.125/0001-35', 'contato@massascomercial.com.br'),
(335, 'Grãos Paulista', '11.211.126/0001-36', 'contato@graospaulista.com.br'),
(336, 'Massas Artesanais SP', '11.211.127/0001-37', 'contato@massasartesanais.com.br'),
(337, 'Distribuidora Grãos Sul', '11.211.128/0001-38', 'contato@graossul.com.br'),
(338, 'Massas Sabor e Arte', '11.211.129/0001-39', 'contato@massassaborarte.com.br'),
(339, 'Grãos Central SP', '11.211.130/0001-40', 'contato@graoscentral.com.br'),
(340, 'Doces Brasil', '22.111.111/0001-41', 'contato@docesbrasil.com.br'),
(341, 'Sobremesas Delícia', '22.111.112/0001-42', 'contato@sobremesasdelicia.com.br'),
(342, 'Confeitaria Central', '22.111.113/0001-43', 'contato@confeitariacentral.com.br'),
(343, 'Doces Premium SP', '22.111.114/0001-44', 'contato@docespremium.com.br'),
(344, 'Sobremesas Mais', '22.111.115/0001-45', 'contato@sobremesasmais.com.br'),
(345, 'Doces & Cia', '22.111.116/0001-46', 'contato@docesecia.com.br'),
(346, 'Delícias do Açúcar', '22.111.117/0001-47', 'contato@deliciasdocacucar.com.br'),
(347, 'Sobremesas Express', '22.111.118/0001-48', 'contato@sobremesasexpress.com.br'),
(348, 'Doces Master', '22.111.119/0001-49', 'contato@docesmaster.com.br'),
(349, 'Sobremesas Paulista', '22.111.120/0001-50', 'contato@sobremesaspaulista.com.br'),
(350, 'Confeitaria União', '22.111.121/0001-51', 'contato@confeitariuniaosp.com.br'),
(351, 'Doces Mais SP', '22.111.122/0001-52', 'contato@docesmaissp.com.br'),
(352, 'Sobremesas Delicatessen', '22.111.123/0001-53', 'contato@sobremesasdelicatessen.com.br'),
(353, 'Doces Top Brasil', '22.111.124/0001-54', 'contato@docestop.com.br'),
(354, 'Sobremesas Sabor', '22.111.125/0001-55', 'contato@sobremesassabor.com.br'),
(355, 'Doces Central SP', '22.111.126/0001-56', 'contato@docescentral.com.br'),
(356, 'Sobremesas Prime', '22.111.127/0001-57', 'contato@sobremesasprime.com.br'),
(357, 'Doces Delicatessen', '22.111.128/0001-58', 'contato@docesdelicatessen.com.br'),
(358, 'Sobremesas Master SP', '22.111.129/0001-59', 'contato@sobremesasmaster.com.br'),
(359, 'Doces Comercial SP', '22.111.130/0001-60', 'contato@docescomercial.com.br'),
(360, 'Salgados Brasil', '33.111.111/0001-61', 'contato@salgadosbrasil.com.br'),
(361, 'Snacks Delícia', '33.111.112/0001-62', 'contato@snacksdelicia.com.br'),
(362, 'Distribuidora Snack SP', '33.111.113/0001-63', 'contato@snacksp.com.br'),
(363, 'Salgados Express', '33.111.114/0001-64', 'contato@salgadosexpress.com.br'),
(364, 'Snacks Top', '33.111.115/0001-65', 'contato@snackstop.com.br'),
(365, 'Salgados Mais SP', '33.111.116/0001-66', 'contato@salgadosmaissp.com.br'),
(366, 'Snacks Premium', '33.111.117/0001-67', 'contato@snackspremium.com.br'),
(367, 'Salgados União SP', '33.111.118/0001-68', 'contato@salgadosuniao.com.br'),
(368, 'Snacks Master', '33.111.119/0001-69', 'contato@snacksmaster.com.br'),
(369, 'Salgados Paulista', '33.111.120/0001-70', 'contato@salgadospaulista.com.br'),
(370, 'Distribuidora Salgados Central', '33.111.121/0001-71', 'contato@salgadoscentral.com.br'),
(371, 'Snacks Mais Brasil', '33.111.122/0001-72', 'contato@snacksmais.com.br'),
(372, 'Salgados Delicatessen', '33.111.123/0001-73', 'contato@salgadosdelicatessen.com.br'),
(373, 'Snacks Central SP', '33.111.124/0001-74', 'contato@snackcentral.com.br'),
(374, 'Salgados Prime', '33.111.125/0001-75', 'contato@salgadosprime.com.br'),
(375, 'Snacks Delícia SP', '33.111.126/0001-76', 'contato@snacksdeliciasp.com.br'),
(376, 'Salgados Top Brasil', '33.111.127/0001-77', 'contato@salgadostop.com.br'),
(377, 'Snacks Comercial SP', '33.111.128/0001-78', 'contato@snackscomercial.com.br'),
(378, 'Salgados Master SP', '33.111.129/0001-79', 'contato@salgadosmaster.com.br'),
(379, 'Snacks Paulista', '33.111.130/0001-80', 'contato@snackspaulista.com.br'),
(380, 'Naturais Brasil', '44.111.111/0001-81', 'contato@naturaisbrasil.com.br'),
(381, 'Orgânicos SP', '44.111.112/0001-82', 'contato@organicossp.com.br'),
(382, 'Bio Produtos', '44.111.113/0001-83', 'contato@bioprodutos.com.br'),
(383, 'Naturais & Cia', '44.111.114/0001-84', 'contato@naturaiscia.com.br'),
(384, 'Orgânicos Premium', '44.111.115/0001-85', 'contato@organicospremium.com.br'),
(385, 'Distribuidora Bio SP', '44.111.116/0001-86', 'contato@biosp.com.br'),
(386, 'Naturais Mais', '44.111.117/0001-87', 'contato@naturaismais.com.br'),
(387, 'Orgânicos Delícia', '44.111.118/0001-88', 'contato@organicosdelicia.com.br'),
(388, 'Bio Central', '44.111.119/0001-89', 'contato@biocentral.com.br'),
(389, 'Naturais Master', '44.111.120/0001-90', 'contato@naturaismaster.com.br'),
(390, 'Orgânicos Paulista', '44.111.121/0001-91', 'contato@organicospaulista.com.br'),
(391, 'Distribuidora Naturais Central', '44.111.122/0001-92', 'contato@naturaiscentral.com.br'),
(392, 'Bio Delicatessen', '44.111.123/0001-93', 'contato@biodelicatessen.com.br'),
(393, 'Naturais Prime SP', '44.111.124/0001-94', 'contato@naturaisprime.com.br'),
(394, 'Orgânicos Top Brasil', '44.111.125/0001-95', 'contato@organicostop.com.br'),
(395, 'Bio Mais SP', '44.111.126/0001-96', 'contato@biomaissp.com.br'),
(396, 'Naturais Express', '44.111.127/0001-97', 'contato@naturaisexpress.com.br'),
(397, 'Orgânicos Comercial', '44.111.128/0001-98', 'contato@organicoscomercial.com.br'),
(398, 'Bio Master SP', '44.111.129/0001-99', 'contato@biomaster.com.br'),
(399, 'Naturais Paulista', '44.111.130/0001-00', 'contato@naturaispaulista.com.br'),
(400, 'Baby Brasil', '55.111.111/0001-01', 'contato@babybrasil.com.br'),
(401, 'Kids SP', '55.111.112/0001-02', 'contato@kidssp.com.br'),
(402, 'Mundo Infantil', '55.111.113/0001-03', 'contato@mundoinfantil.com.br'),
(403, 'Bebês & Cia', '55.111.114/0001-04', 'contato@bebesecia.com.br'),
(404, 'Baby Premium SP', '55.111.115/0001-05', 'contato@babypremium.com.br'),
(405, 'Distribuidora Kids Central', '55.111.116/0001-06', 'contato@kidscentral.com.br'),
(406, 'Mundo Baby', '55.111.117/0001-07', 'contato@mundobaby.com.br'),
(407, 'Kids Master', '55.111.118/0001-08', 'contato@kidsmaster.com.br'),
(408, 'Bebês Paulista', '55.111.119/0001-09', 'contato@bebespaulista.com.br'),
(409, 'Baby Express SP', '55.111.120/0001-10', 'contato@babyexpress.com.br'),
(410, 'Kids Delícia SP', '55.111.121/0001-11', 'contato@kidsdelicia.com.br'),
(411, 'Mundo Infantil Premium', '55.111.122/0001-12', 'contato@mundoinfantilpremium.com.br'),
(412, 'Bebês Central SP', '55.111.123/0001-13', 'contato@bebescentral.com.br'),
(413, 'Baby Prime', '55.111.124/0001-14', 'contato@babyprime.com.br'),
(414, 'Kids Top Brasil', '55.111.125/0001-15', 'contato@kidstop.com.br'),
(415, 'Bebês Mais SP', '55.111.126/0001-16', 'contato@bebesmaissp.com.br'),
(416, 'Mundo Baby Express', '55.111.127/0001-17', 'contato@mundobabyexpress.com.br'),
(417, 'Kids Comercial SP', '55.111.128/0001-18', 'contato@kidscomercial.com.br'),
(418, 'Bebês Master SP', '55.111.129/0001-19', 'contato@bebesmaster.com.br'),
(419, 'Baby Paulista', '55.111.130/0001-20', 'contato@babypaulista.com.br'),
(420, 'Pet Brasil', '66.111.111/0001-01', 'contato@petbrasil.com.br'),
(421, 'Pets SP', '66.111.112/0001-02', 'contato@petssp.com.br'),
(422, 'Pet Mania', '66.111.113/0001-03', 'contato@petmania.com.br'),
(423, 'Pet & Cia', '66.111.114/0001-04', 'contato@petecia.com.br'),
(424, 'Pet Premium SP', '66.111.115/0001-05', 'contato@petpremium.com.br'),
(425, 'Distribuidora Pet Central', '66.111.116/0001-06', 'contato@petcentral.com.br'),
(426, 'Pet Master SP', '66.111.117/0001-07', 'contato@petmaster.com.br'),
(427, 'Pet Paulista', '66.111.118/0001-08', 'contato@petpaulista.com.br'),
(428, 'Pet Express SP', '66.111.119/0001-09', 'contato@petexpress.com.br'),
(429, 'Pet Delícia SP', '66.111.120/0001-10', 'contato@petdelicia.com.br'),
(430, 'Pet Top Brasil', '66.111.121/0001-11', 'contato@pettop.com.br'),
(431, 'Pet Mais SP', '66.111.122/0001-12', 'contato@petmaissp.com.br'),
(432, 'Pet Comercial SP', '66.111.123/0001-13', 'contato@petcomercial.com.br'),
(433, 'Pet Delicatessen', '66.111.124/0001-14', 'contato@petdelicatessen.com.br'),
(434, 'Pet Central Premium', '66.111.125/0001-15', 'contato@petcentralpremium.com.br'),
(435, 'Pet Express Brasil', '66.111.126/0001-16', 'contato@petexpressbrasil.com.br'),
(436, 'Pet Master Premium', '66.111.127/0001-17', 'contato@petmasterpremium.com.br'),
(437, 'Pet Mais Brasil', '66.111.128/0001-18', 'contato@petmaisbrasil.com.br'),
(438, 'Pet Comercial Premium', '66.111.129/0001-19', 'contato@petcomercialpremium.com.br'),
(439, 'Pet Paulista Premium', '66.111.130/0001-20', 'contato@petpaulistapremium.com.br'),
(440, 'Casa & Cia', '77.111.111/0001-01', 'contato@casaecia.com.br'),
(441, 'Utilidades SP', '77.111.112/0001-02', 'contato@utilidadessp.com.br'),
(442, 'Lar Central', '77.111.113/0001-03', 'contato@larcentral.com.br'),
(443, 'Casa Premium', '77.111.114/0001-04', 'contato@casapremium.com.br'),
(444, 'Distribuidora Lar SP', '77.111.115/0001-05', 'contato@larsp.com.br'),
(445, 'Casa Master', '77.111.116/0001-06', 'contato@casamaster.com.br'),
(446, 'Utilidades Mais SP', '77.111.117/0001-07', 'contato@utilidadesmaissp.com.br'),
(447, 'Lar Express', '77.111.118/0001-08', 'contato@larexpress.com.br'),
(448, 'Casa Delícia', '77.111.119/0001-09', 'contato@casadelicia.com.br'),
(449, 'Utilidades Paulista', '77.111.120/0001-10', 'contato@utilidadespaulista.com.br'),
(450, 'Casa Prime SP', '77.111.121/0001-11', 'contato@casaprime.com.br'),
(451, 'Lar Top Brasil', '77.111.122/0001-12', 'contato@lartop.com.br'),
(452, 'Distribuidora Casa Central', '77.111.123/0001-13', 'contato@casacentral.com.br'),
(453, 'Utilidades Delicatessen', '77.111.124/0001-14', 'contato@utilidadesdelicatessen.com.br'),
(454, 'Casa Mais Brasil', '77.111.125/0001-15', 'contato@casamaisbrasil.com.br'),
(455, 'Lar Comercial SP', '77.111.126/0001-16', 'contato@larcomercial.com.br'),
(456, 'Casa Express Brasil', '77.111.127/0001-17', 'contato@casaexpressbrasil.com.br'),
(457, 'Utilidades Master SP', '77.111.128/0001-18', 'contato@utilidadesmaster.com.br'),
(458, 'Lar Paulista Premium', '77.111.129/0001-19', 'contato@larpaulistapremium.com.br'),
(459, 'Casa Comercial SP', '77.111.130/0001-20', 'contato@casacomercial.com.br'),
(460, 'Congelados Brasil Gourmet', '88.111.111/0001-21', 'contato@congeladosbrasilgourmet.com.br'),
(461, 'Prontos SP Premium', '88.111.112/0001-22', 'contato@prontospremium.com.br'),
(462, 'Frozen Mania Express', '88.111.113/0001-23', 'contato@frozenmaniaexpress.com.br'),
(463, 'Congelados & Cia Delícia', '88.111.114/0001-24', 'contato@congeladosciadelicia.com.br'),
(464, 'Prontos Premium Brasil', '88.111.115/0001-25', 'contato@prontospremiumbrasil.com.br'),
(465, 'Distribuidora Frozen Central SP', '88.111.116/0001-26', 'contato@frozencentralsp.com.br'),
(466, 'Congelados Master Gourmet', '88.111.117/0001-27', 'contato@congeladosmastergourmet.com.br'),
(467, 'Prontos Paulista Express', '88.111.118/0001-28', 'contato@prontospaulistaexpress.com.br'),
(468, 'Frozen Express Brasil', '88.111.119/0001-29', 'contato@frozenexpressbrasil.com.br'),
(469, 'Congelados Delícia SP', '88.111.120/0001-30', 'contato@congeladosdeliciasp.com.br'),
(470, 'Prontos Top Gourmet', '88.111.121/0001-31', 'contato@prontostopgourmet.com.br'),
(471, 'Frozen Mais Brasil', '88.111.122/0001-32', 'contato@frozenmaisbrasil.com.br'),
(472, 'Congelados Delicatessen SP', '88.111.123/0001-33', 'contato@congeladosdelicatessensp.com.br'),
(473, 'Prontos Central Express', '88.111.124/0001-34', 'contato@prontoscentralexpress.com.br'),
(474, 'Frozen Prime Brasil', '88.111.125/0001-35', 'contato@frozenprimebrasil.com.br'),
(475, 'Congelados Express Gourmet', '88.111.126/0001-36', 'contato@congeladosexpressgourmet.com.br'),
(476, 'Prontos Master SP', '88.111.127/0001-37', 'contato@prontosmastersp.com.br'),
(477, 'Frozen Paulista Gourmet', '88.111.128/0001-38', 'contato@frozenpaulistagourmet.com.br'),
(478, 'Congelados Comercial Express', '88.111.129/0001-39', 'contato@congeladoscomercialexpress.com.br'),
(479, 'Prontos Delícia Gourmet', '88.111.130/0001-40', 'contato@prontosdeliciagourmet.com.br'),
(480, 'Importados Brasil Gourmet', '99.111.111/0001-21', 'contato@importadosbrasilgourmet.com.br'),
(481, 'World Imports SP Premium', '99.111.112/0001-22', 'contato@worldimportsspremium.com.br'),
(482, 'Global Products Express', '99.111.113/0001-23', 'contato@globalproductsexpress.com.br'),
(483, 'Importados & Cia Delícia', '99.111.114/0001-24', 'contato@importadosciadelicia.com.br'),
(484, 'Premium Imports Brasil', '99.111.115/0001-25', 'contato@premiumimportsbrasil.com.br'),
(485, 'Distribuidora Global Central SP', '99.111.116/0001-26', 'contato@globalcentralsp.com.br'),
(486, 'Importados Master Gourmet', '99.111.117/0001-27', 'contato@importadosmastergourmet.com.br'),
(487, 'Imports Paulista Express', '99.111.118/0001-28', 'contato@importspaulistaexpress.com.br'),
(488, 'Express Imports Brasil', '99.111.119/0001-29', 'contato@expressimportsbrasil.com.br'),
(489, 'Importados Delícia SP', '99.111.120/0001-30', 'contato@importadosdeliciasp.com.br'),
(490, 'Top Imports Brasil Gourmet', '99.111.121/0001-31', 'contato@topimportsbrasilgourmet.com.br'),
(491, 'Global Mais Express SP', '99.111.122/0001-32', 'contato@globalmaissexpress.com.br'),
(492, 'Importados Delicatessen SP', '99.111.123/0001-33', 'contato@importadosdelicatessensp.com.br'),
(493, 'Central Imports Brasil', '99.111.124/0001-34', 'contato@centralimportsbrasil.com.br'),
(494, 'Premium Imports Express SP', '99.111.125/0001-35', 'contato@premiumimportsexpress.com.br'),
(495, 'Express Global Imports', '99.111.126/0001-36', 'contato@expressglobalimports.com.br'),
(496, 'Master Imports Brasil Gourmet', '99.111.127/0001-37', 'contato@masterimportsbrasilgourmet.com.br'),
(497, 'Imports Mais Brasil Premium', '99.111.128/0001-38', 'contato@importsmaisbrasilpremium.com.br'),
(498, 'Comercial Imports SP Gourmet', '99.111.129/0001-39', 'contato@comercialimportsgourmet.com.br'),
(499, 'Imports Paulista Premium Express', '99.111.130/0001-40', 'contato@importspaulistapremiumexpress.com.br'),
(502, 'Tenda', '123465789', 'tenda@gmail.com'),
(503, 'Thiago Teste', '00000000000000000000', 'thiago@thiago.com'),
(504, 'Sabonestes do mar', '12345678912', 'sjdsja@dsajhdajhs');

-- --------------------------------------------------------

--
-- Estrutura para tabela `funcionario`
--

CREATE TABLE `funcionario` (
  `id_funcionario` int(11) NOT NULL,
  `nome_funcionario` varchar(50) NOT NULL,
  `cpf_funcionario` varchar(11) NOT NULL,
  `email_funcionario` varchar(50) NOT NULL,
  `id_cargo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `funcionario`
--

INSERT INTO `funcionario` (`id_funcionario`, `nome_funcionario`, `cpf_funcionario`, `email_funcionario`, `id_cargo`) VALUES
(1, 'Felipe dos Santos', '12345678910', 'felipe@gmail.com', 1),
(2, 'Alice ', '23456789101', 'alice@gmail.com', 1),
(11, 'João', '45632987469', 'joao.p@gmail.com', 3),
(14, 'Paulo', '4563298787', 'paulo@gmail.com', 7);

-- --------------------------------------------------------

--
-- Estrutura para tabela `pedido`
--

CREATE TABLE `pedido` (
  `id_pedido` int(11) NOT NULL,
  `cpf` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `pedido`
--

INSERT INTO `pedido` (`id_pedido`, `cpf`) VALUES
(1, ''),
(2, '');

-- --------------------------------------------------------

--
-- Estrutura para tabela `pedido_item`
--

CREATE TABLE `pedido_item` (
  `id_item` int(11) NOT NULL,
  `id_pedido` int(11) NOT NULL,
  `id_produto` int(11) NOT NULL,
  `quantidade_item` int(11) NOT NULL,
  `preco_unitario` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `pedido_item`
--

INSERT INTO `pedido_item` (`id_item`, `id_pedido`, `id_produto`, `quantidade_item`, `preco_unitario`) VALUES
(3, 1, 23, 2, 19.90),
(4, 1, 25, 1, 49.90),
(5, 1, 23, 3, 9.99),
(6, 1, 25, 4, 99.90),
(7, 1, 23, 2, 29.90),
(8, 1, 25, 1, 15.00),
(9, 1, 23, 3, 35.50),
(10, 1, 25, 2, 19.90),
(11, 1, 23, 1, 49.90),
(12, 1, 25, 5, 9.99),
(13, 2, 23, 1, 19.90),
(14, 2, 25, 3, 49.90),
(15, 2, 23, 2, 9.99),
(16, 2, 25, 4, 99.90),
(17, 2, 23, 1, 29.90),
(18, 2, 25, 2, 15.00),
(19, 2, 23, 3, 35.50),
(20, 2, 25, 2, 19.90),
(21, 2, 23, 1, 49.90),
(22, 2, 25, 5, 9.99);

-- --------------------------------------------------------

--
-- Estrutura para tabela `produto`
--

CREATE TABLE `produto` (
  `id_produto` int(11) NOT NULL,
  `nome_produto` varchar(50) NOT NULL,
  `preco_produto` decimal(10,2) NOT NULL,
  `codigo_produto` varchar(15) NOT NULL,
  `id_categoria` int(11) NOT NULL,
  `id_fornecedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `produto`
--

INSERT INTO `produto` (`id_produto`, `nome_produto`, `preco_produto`, `codigo_produto`, `id_categoria`, `id_fornecedor`) VALUES
(23, 'sabonete', 3.99, '6645', 4, 105),
(25, 'Pão normal', 5.00, '6371', 6, 126),
(26, 'Pão de forma', 10.90, '4545', 6, 207);

-- --------------------------------------------------------

--
-- Estrutura para tabela `telefone_fornecedor`
--

CREATE TABLE `telefone_fornecedor` (
  `id_telefone_fornecedor` int(11) NOT NULL,
  `telefone_fornecedor` varchar(11) NOT NULL,
  `id_fornecedor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `telefone_fornecedor`
--

INSERT INTO `telefone_fornecedor` (`id_telefone_fornecedor`, `telefone_fornecedor`, `id_fornecedor`) VALUES
(1, '(11) 91234-', 1),
(2, '11990000001', 100),
(3, '11990000002', 101),
(4, '11990000003', 102),
(5, '11990000004', 103),
(6, '11990000005', 104),
(7, '11990000006', 105),
(8, '11990000007', 106),
(9, '11990000008', 107),
(10, '11990000009', 108),
(11, '11990000010', 109),
(12, '11990000011', 110),
(13, '11990000012', 111),
(14, '11990000013', 112),
(15, '11990000014', 113),
(16, '11990000015', 114),
(17, '11990000016', 115),
(18, '11990000017', 116),
(19, '11990000018', 117),
(20, '11990000019', 118),
(21, '11990000020', 119),
(22, '11990000021', 120),
(23, '11990000022', 121),
(24, '11990000023', 122),
(25, '11990000024', 123),
(26, '11990000025', 124),
(27, '11990000026', 125),
(28, '11990000027', 126),
(29, '11990000028', 127),
(30, '11990000029', 128),
(31, '11990000030', 129),
(32, '11990000031', 130),
(33, '11990000032', 131),
(34, '11990000033', 132),
(35, '11990000034', 133),
(36, '11990000035', 134),
(37, '11990000036', 135),
(38, '11990000037', 136),
(39, '11990000038', 137),
(40, '11990000039', 138),
(41, '11990000040', 139),
(42, '11987650001', 140),
(43, '11987650002', 141),
(44, '11987650003', 142),
(45, '11987650004', 143),
(46, '11987650005', 144),
(47, '11987650006', 145),
(48, '11987650007', 146),
(49, '11987650008', 147),
(50, '11987650009', 148),
(51, '11987650010', 149),
(52, '11987650011', 150),
(53, '11987650012', 151),
(54, '11987650013', 152),
(55, '11987650014', 153),
(56, '11987650015', 154),
(57, '11987650016', 155),
(58, '11987650017', 156),
(59, '11987650018', 157),
(60, '11987650019', 158),
(61, '11987650020', 159),
(62, '11987660001', 160),
(63, '11987660002', 161),
(64, '11987660003', 162),
(65, '11987660004', 163),
(66, '11987660005', 164),
(67, '11987660006', 165),
(68, '11987660007', 166),
(69, '11987660008', 167),
(70, '11987660009', 168),
(71, '11987660010', 169),
(72, '11987660011', 170),
(73, '11987660012', 171),
(74, '11987660013', 172),
(75, '11987660014', 173),
(76, '11987660015', 174),
(77, '11987660016', 175),
(78, '11987660017', 176),
(79, '11987660018', 177),
(80, '11987660019', 178),
(81, '11987660020', 179),
(82, '11987670001', 180),
(83, '11987670002', 181),
(84, '11987670003', 182),
(85, '11987670004', 183),
(86, '11987670005', 184),
(87, '11987670006', 185),
(88, '11987670007', 186),
(89, '11987670008', 187),
(90, '11987670009', 188),
(91, '11987670010', 189),
(92, '11987670011', 190),
(93, '11987670012', 191),
(94, '11987670013', 192),
(95, '11987670014', 193),
(96, '11987670015', 194),
(97, '11987670016', 195),
(98, '11987670017', 196),
(99, '11987670018', 197),
(100, '11987670019', 198),
(101, '11987670020', 199),
(102, '11987680001', 200),
(103, '11987680002', 201),
(104, '11987680003', 202),
(105, '11987680004', 203),
(106, '11987680005', 204),
(107, '11987680006', 205),
(108, '11987680007', 206),
(109, '11987680008', 207),
(110, '11987680009', 208),
(111, '11987680010', 209),
(112, '11987680011', 210),
(113, '11987680012', 211),
(114, '11987680013', 212),
(115, '11987680014', 213),
(116, '11987680015', 214),
(117, '11987680016', 215),
(118, '11987680017', 216),
(119, '11987680018', 217),
(120, '11987680019', 218),
(121, '11987680020', 219),
(122, '11987710001', 220),
(123, '11987710002', 221),
(124, '11987710003', 222),
(125, '11987710004', 223),
(126, '11987710005', 224),
(127, '11987710006', 225),
(128, '11987710007', 226),
(129, '11987710008', 227),
(130, '11987710009', 228),
(131, '11987710010', 229),
(132, '11987710011', 230),
(133, '11987710012', 231),
(134, '11987710013', 232),
(135, '11987710014', 233),
(136, '11987710015', 234),
(137, '11987710016', 235),
(138, '11987710017', 236),
(139, '11987710018', 237),
(140, '11987710019', 238),
(141, '11987710020', 239),
(142, '11987720001', 240),
(143, '11987720002', 241),
(144, '11987720003', 242),
(145, '11987720004', 243),
(146, '11987720005', 244),
(147, '11987720006', 245),
(148, '11987720007', 246),
(149, '11987720008', 247),
(150, '11987720009', 248),
(151, '11987720010', 249),
(152, '11987720011', 250),
(153, '11987720012', 251),
(154, '11987720013', 252),
(155, '11987720014', 253),
(156, '11987720015', 254),
(157, '11987720016', 255),
(158, '11987720017', 256),
(159, '11987720018', 257),
(160, '11987720019', 258),
(161, '11987720020', 259),
(162, '11987730001', 260),
(163, '11987730002', 261),
(164, '11987730003', 262),
(165, '11987730004', 263),
(166, '11987730005', 264),
(167, '11987730006', 265),
(168, '11987730007', 266),
(169, '11987730008', 267),
(170, '11987730009', 268),
(171, '11987730010', 269),
(172, '11987730011', 270),
(173, '11987730012', 271),
(174, '11987730013', 272),
(175, '11987730014', 273),
(176, '11987730015', 274),
(177, '11987730016', 275),
(178, '11987730017', 276),
(179, '11987730018', 277),
(180, '11987730019', 278),
(181, '11987730020', 279),
(182, '11987740001', 280),
(183, '11987740002', 281),
(184, '11987740003', 282),
(185, '11987740004', 283),
(186, '11987740005', 284),
(187, '11987740006', 285),
(188, '11987740007', 286),
(189, '11987740008', 287),
(190, '11987740009', 288),
(191, '11987740010', 289),
(192, '11987740011', 290),
(193, '11987740012', 291),
(194, '11987740013', 292),
(195, '11987740014', 293),
(196, '11987740015', 294),
(197, '11987740016', 295),
(198, '11987740017', 296),
(199, '11987740018', 297),
(200, '11987740019', 298),
(201, '11987740020', 299),
(202, '11987750001', 300),
(203, '11987750002', 301),
(204, '11987750003', 302),
(205, '11987750004', 303),
(206, '11987750005', 304),
(207, '11987750006', 305),
(208, '11987750007', 306),
(209, '11987750008', 307),
(210, '11987750009', 308),
(211, '11987750010', 309),
(212, '11987750011', 310),
(213, '11987750012', 311),
(214, '11987750013', 312),
(215, '11987750014', 313),
(216, '11987750015', 314),
(217, '11987750016', 315),
(218, '11987750017', 316),
(219, '11987750018', 317),
(220, '11987750019', 318),
(221, '11987750020', 319),
(222, '11987760001', 320),
(223, '11987760002', 321),
(224, '11987760003', 322),
(225, '11987760004', 323),
(226, '11987760005', 324),
(227, '11987760006', 325),
(228, '11987760007', 326),
(229, '11987760008', 327),
(230, '11987760009', 328),
(231, '11987760010', 329),
(232, '11987760011', 330),
(233, '11987760012', 331),
(234, '11987760013', 332),
(235, '11987760014', 333),
(236, '11987760015', 334),
(237, '11987760016', 335),
(238, '11987760017', 336),
(239, '11987760018', 337),
(240, '11987760019', 338),
(241, '11987760020', 339),
(242, '11987770001', 340),
(243, '11987770002', 341),
(244, '11987770003', 342),
(245, '11987770004', 343),
(246, '11987770005', 344),
(247, '11987770006', 345),
(248, '11987770007', 346),
(249, '11987770008', 347),
(250, '11987770009', 348),
(251, '11987770010', 349),
(252, '11987770011', 350),
(253, '11987770012', 351),
(254, '11987770013', 352),
(255, '11987770014', 353),
(256, '11987770015', 354),
(257, '11987770016', 355),
(258, '11987770017', 356),
(259, '11987770018', 357),
(260, '11987770019', 358),
(261, '11987770020', 359),
(262, '11987780001', 360),
(263, '11987780002', 361),
(264, '11987780003', 362),
(265, '11987780004', 363),
(266, '11987780005', 364),
(267, '11987780006', 365),
(268, '11987780007', 366),
(269, '11987780008', 367),
(270, '11987780009', 368),
(271, '11987780010', 369),
(272, '11987780011', 370),
(273, '11987780012', 371),
(274, '11987780013', 372),
(275, '11987780014', 373),
(276, '11987780015', 374),
(277, '11987780016', 375),
(278, '11987780017', 376),
(279, '11987780018', 377),
(280, '11987780019', 378),
(281, '11987780020', 379),
(282, '11987790001', 380),
(283, '11987790002', 381),
(284, '11987790003', 382),
(285, '11987790004', 383),
(286, '11987790005', 384),
(287, '11987790006', 385),
(288, '11987790007', 386),
(289, '11987790008', 387),
(290, '11987790009', 388),
(291, '11987790010', 389),
(292, '11987790011', 390),
(293, '11987790012', 391),
(294, '11987790013', 392),
(295, '11987790014', 393),
(296, '11987790015', 394),
(297, '11987790016', 395),
(298, '11987790017', 396),
(299, '11987790018', 397),
(300, '11987790019', 398),
(301, '11987790020', 399),
(302, '11987800001', 400),
(303, '11987800002', 401),
(304, '11987800003', 402),
(305, '11987800004', 403),
(306, '11987800005', 404),
(307, '11987800006', 405),
(308, '11987800007', 406),
(309, '11987800008', 407),
(310, '11987800009', 408),
(311, '11987800010', 409),
(312, '11987800011', 410),
(313, '11987800012', 411),
(314, '11987800013', 412),
(315, '11987800014', 413),
(316, '11987800015', 414),
(317, '11987800016', 415),
(318, '11987800017', 416),
(319, '11987800018', 417),
(320, '11987800019', 418),
(321, '11987800020', 419),
(322, '11987810001', 420),
(323, '11987810002', 421),
(324, '11987810003', 422),
(325, '11987810004', 423),
(326, '11987810005', 424),
(327, '11987810006', 425),
(328, '11987810007', 426),
(329, '11987810008', 427),
(330, '11987810009', 428),
(331, '11987810010', 429),
(332, '11987810011', 430),
(333, '11987810012', 431),
(334, '11987810013', 432),
(335, '11987810014', 433),
(336, '11987810015', 434),
(337, '11987810016', 435),
(338, '11987810017', 436),
(339, '11987810018', 437),
(340, '11987810019', 438),
(341, '11987810020', 439),
(342, '11987820001', 440),
(343, '11987820002', 441),
(344, '11987820003', 442),
(345, '11987820004', 443),
(346, '11987820005', 444),
(347, '11987820006', 445),
(348, '11987820007', 446),
(349, '11987820008', 447),
(350, '11987820009', 448),
(351, '11987820010', 449),
(352, '11987820011', 450),
(353, '11987820012', 451),
(354, '11987820013', 452),
(355, '11987820014', 453),
(356, '11987820015', 454),
(357, '11987820016', 455),
(358, '11987820017', 456),
(359, '11987820018', 457),
(360, '11987820019', 458),
(361, '11987820020', 459),
(362, '11987830021', 460),
(363, '11987830022', 461),
(364, '11987830023', 462),
(365, '11987830024', 463),
(366, '11987830025', 464),
(367, '11987830026', 465),
(368, '11987830027', 466),
(369, '11987830028', 467),
(370, '11987830029', 468),
(371, '11987830030', 469),
(372, '11987830031', 470),
(373, '11987830032', 471),
(374, '11987830033', 472),
(375, '11987830034', 473),
(376, '11987830035', 474),
(377, '11987830036', 475),
(378, '11987830037', 476),
(379, '11987830038', 477),
(380, '11987830039', 478),
(381, '11987830040', 479),
(382, '11987840021', 480),
(383, '11987840022', 481),
(384, '11987840023', 482),
(385, '11987840024', 483),
(386, '11987840025', 484),
(387, '11987840026', 485),
(388, '11987840027', 486),
(389, '11987840028', 487),
(390, '11987840029', 488),
(391, '11987840030', 489),
(392, '11987840031', 490),
(393, '11987840032', 491),
(394, '11987840033', 492),
(395, '11987840034', 493),
(396, '11987840035', 494),
(397, '11987840036', 495),
(398, '11987840037', 496),
(399, '11987840038', 497),
(400, '11987840039', 498),
(401, '11987840040', 499),
(403, '5555555', 502),
(404, '12666666666', 503),
(405, '12554498494', 504);

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `email` varchar(100) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`id`, `username`, `password_hash`, `email`, `created_at`) VALUES
(1, 'diogo', '$2a$12$r9zJ18kzpPPJLbqXyTqUDOF6Cjpffh/8y5i4oJ/EGy8VEJ2RoYNQu', 'diogo@exemplo.com', '2026-03-12 00:53:48'),
(2, 'maria', '$2a$12$clqOOc5vQYoW2hZKMPH4IuzTJhiMZfciQvxCd/H31z5AfaL4mYedu', 'maria@gmail.com', '2026-03-12 00:59:55'),
(3, 'sergio', '$2a$12$jj9wI34Ko4ONiPA41q0To.rgDjhwZUTm6dI6KXtZ6NqQS8zcoGq/W', 'sergio@gmail.com', '2026-03-19 22:23:20'),
(4, 'diogo1', '$2a$12$1myhdW7CSOSBIPKZX9y88OD0G5sCFOYHPJ70nU8rw3YyQ2IPddjVa', 'diogo1@gmail.com', '2026-03-19 23:15:54'),
(5, 'diogo2', '$2a$12$QPLA8ls285fXO/jgw1XHYeu7STYJhZbfjxtDhC/eIUaGUrUlsl6ba', 'diogo2@gmail.com', '2026-03-19 23:19:28'),
(6, 'diogo3', '$2a$12$WJrxk6Ezd08B65LSnlahr.eSd7ahqQDwF4TLw/uk3LwWTLvlDjdXm', 'diogo3@gmail.com', '2026-03-19 23:20:11'),
(7, 'Luanda', '$2a$12$aoza08dbl0riM0YLqHshcOifWUhlFdexOrkZsQU9COiqLU4OU3TqG', 'luanda@gmail.com', '2026-03-21 00:57:31'),
(8, 'brayan', '$2a$12$lQt4scvc67JhW3Ko0wT2/.BNFkRE.nnvSiXqg8ZSWULz6USIsQmhO', 'brayan@gmail.com', '2026-03-26 23:24:18'),
(9, 'felipe', '$2a$12$610qgc.bxHTQsr8Ot9IUiud7f8CoDX34RT9vsrMD15WpZG0aGgIhC', 'felipe@gmail.com', '2026-04-02 22:05:53'),
(10, 'fernanda', '$2a$12$4hvHFr9.1Nb.TTGsVVIOOO7VabwL6VJBjDj9j5tU30nHLAROrb5aO', 'fernanda@gmail.com', '2026-04-03 00:40:31'),
(11, 'alice', '$2a$12$tju3nLAH5UY5jOtWMNqxqe0UReArt.SES9eL57AG.pTPnirQ9jWOS', 'alice.98@gmail.com', '2026-04-08 22:24:41'),
(13, 'ludmylla7', '$2a$12$1v6gWDmNlFuFnlsBz1qqseqArpDytgyg4Bpr0HTS1FL6SnTOF4nJW', 'ludmylla@gmail.com', '2026-04-08 22:56:42');

-- --------------------------------------------------------

--
-- Estrutura para tabela `venda`
--

CREATE TABLE `venda` (
  `id_venda` int(11) NOT NULL,
  `id_pedido` int(11) NOT NULL,
  `data_venda` datetime NOT NULL DEFAULT current_timestamp(),
  `id_forma_pagamento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `venda`
--

INSERT INTO `venda` (`id_venda`, `id_pedido`, `data_venda`, `id_forma_pagamento`) VALUES
(3, 2, '2026-03-19 21:18:23', 2),
(24, 1, '2026-04-08 20:16:43', 1),
(25, 1, '2026-04-08 20:16:43', 2),
(26, 1, '2026-04-08 20:16:43', 3),
(27, 1, '2026-04-08 20:16:43', 4),
(28, 1, '2026-04-08 20:16:43', 1),
(29, 1, '2026-04-08 20:16:43', 2),
(30, 1, '2026-04-08 20:16:43', 3),
(31, 1, '2026-04-08 20:16:43', 4),
(32, 1, '2026-04-08 20:16:43', 1),
(33, 1, '2026-04-08 20:16:43', 2),
(34, 2, '2026-04-08 20:16:43', 3),
(35, 2, '2026-04-08 20:16:43', 4),
(36, 2, '2026-04-08 20:16:43', 1),
(37, 2, '2026-04-08 20:16:43', 2),
(38, 2, '2026-04-08 20:16:43', 3),
(39, 2, '2026-04-08 20:16:43', 4),
(40, 2, '2026-04-08 20:16:43', 1),
(41, 2, '2026-04-08 20:16:43', 2),
(42, 2, '2026-04-08 20:16:43', 3),
(43, 2, '2026-04-08 20:16:43', 4);

-- --------------------------------------------------------

--
-- Estrutura stand-in para view `vw_funcionario`
-- (Veja abaixo para a visão atual)
--
CREATE TABLE `vw_funcionario` (
`id_funcionario` int(11)
,`nome_funcionario` varchar(50)
,`email_funcionario` varchar(50)
,`cpf_funcionario` varchar(11)
,`nome_cargo` varchar(20)
,`telefone_funcionario` varchar(20)
,`pais_funcionario` varchar(20)
,`estado_funcionario` varchar(20)
,`cidade_funcionario` varchar(20)
,`bairro_funcionario` varchar(20)
,`rua_funcionario` varchar(20)
,`cep_funcionario` varchar(18)
,`numero_funcionario` varchar(10)
,`complemento_funcionario` varchar(20)
);

-- --------------------------------------------------------

--
-- Estrutura para view `vw_funcionario`
--
DROP TABLE IF EXISTS `vw_funcionario`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_funcionario`  AS SELECT `f`.`id_funcionario` AS `id_funcionario`, `f`.`nome_funcionario` AS `nome_funcionario`, `f`.`email_funcionario` AS `email_funcionario`, `f`.`cpf_funcionario` AS `cpf_funcionario`, `c`.`nome_cargo` AS `nome_cargo`, `t`.`telefone_funcionario` AS `telefone_funcionario`, `e`.`pais_funcionario` AS `pais_funcionario`, `e`.`estado_funcionario` AS `estado_funcionario`, `e`.`cidade_funcionario` AS `cidade_funcionario`, `e`.`bairro_funcionario` AS `bairro_funcionario`, `e`.`rua_funcionario` AS `rua_funcionario`, `e`.`cep_funcionario` AS `cep_funcionario`, `e`.`numero_funcionario` AS `numero_funcionario`, `e`.`complemento_funcionario` AS `complemento_funcionario` FROM (((`funcionario` `f` join `cargos` `c` on(`f`.`id_cargo` = `c`.`id_cargo`)) join `contato_funcionario` `t` on(`f`.`id_funcionario` = `t`.`id_funcionario`)) join `endereco_funcionario` `e` on(`f`.`id_funcionario` = `e`.`id_funcionario`)) ;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `cargos`
--
ALTER TABLE `cargos`
  ADD PRIMARY KEY (`id_cargo`);

--
-- Índices de tabela `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`id_categoria`);

--
-- Índices de tabela `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`id_cliente`);

--
-- Índices de tabela `contato_cliente`
--
ALTER TABLE `contato_cliente`
  ADD PRIMARY KEY (`id_contato_cliente`),
  ADD KEY `id_cliente` (`id_cliente`);

--
-- Índices de tabela `contato_funcionario`
--
ALTER TABLE `contato_funcionario`
  ADD PRIMARY KEY (`id_contato_funcionario`),
  ADD KEY `contato_funcionario` (`id_funcionario`);

--
-- Índices de tabela `endereco_cliente`
--
ALTER TABLE `endereco_cliente`
  ADD PRIMARY KEY (`id_endereco_cliente`),
  ADD KEY `id_cliente` (`id_cliente`);

--
-- Índices de tabela `endereco_fornecedor`
--
ALTER TABLE `endereco_fornecedor`
  ADD PRIMARY KEY (`id_endereco_fornecedor`),
  ADD KEY `id_fornecedor` (`id_fornecedor`);

--
-- Índices de tabela `endereco_funcionario`
--
ALTER TABLE `endereco_funcionario`
  ADD PRIMARY KEY (`id_endereco_funcionario`),
  ADD KEY `endereco_funcionario` (`id_funcionario`);

--
-- Índices de tabela `estoque`
--
ALTER TABLE `estoque`
  ADD PRIMARY KEY (`id_estoque`),
  ADD KEY `id_produto` (`id_produto`),
  ADD KEY `id_fornecedor` (`id_fornecedor`);

--
-- Índices de tabela `forma_pagamento`
--
ALTER TABLE `forma_pagamento`
  ADD PRIMARY KEY (`id_forma_pagamento`);

--
-- Índices de tabela `fornecedor`
--
ALTER TABLE `fornecedor`
  ADD PRIMARY KEY (`id_fornecedor`),
  ADD UNIQUE KEY `cnpj_fornecedor` (`cnpj_fornecedor`),
  ADD UNIQUE KEY `email_fornecedor` (`email_fornecedor`);

--
-- Índices de tabela `funcionario`
--
ALTER TABLE `funcionario`
  ADD PRIMARY KEY (`id_funcionario`),
  ADD KEY `id_cargo` (`id_cargo`);

--
-- Índices de tabela `pedido`
--
ALTER TABLE `pedido`
  ADD PRIMARY KEY (`id_pedido`);

--
-- Índices de tabela `pedido_item`
--
ALTER TABLE `pedido_item`
  ADD PRIMARY KEY (`id_item`),
  ADD KEY `id_produto` (`id_produto`),
  ADD KEY `id_pedido` (`id_pedido`);

--
-- Índices de tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`id_produto`),
  ADD KEY `id_categoria` (`id_categoria`),
  ADD KEY `id_fornecedor` (`id_fornecedor`);

--
-- Índices de tabela `telefone_fornecedor`
--
ALTER TABLE `telefone_fornecedor`
  ADD PRIMARY KEY (`id_telefone_fornecedor`),
  ADD KEY `id_fornecedor` (`id_fornecedor`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Índices de tabela `venda`
--
ALTER TABLE `venda`
  ADD PRIMARY KEY (`id_venda`),
  ADD KEY `idpedido` (`id_pedido`),
  ADD KEY `forma_pagamento` (`id_forma_pagamento`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `cargos`
--
ALTER TABLE `cargos`
  MODIFY `id_cargo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de tabela `categoria`
--
ALTER TABLE `categoria`
  MODIFY `id_categoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT de tabela `cliente`
--
ALTER TABLE `cliente`
  MODIFY `id_cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `contato_cliente`
--
ALTER TABLE `contato_cliente`
  MODIFY `id_contato_cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `contato_funcionario`
--
ALTER TABLE `contato_funcionario`
  MODIFY `id_contato_funcionario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `endereco_cliente`
--
ALTER TABLE `endereco_cliente`
  MODIFY `id_endereco_cliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `endereco_fornecedor`
--
ALTER TABLE `endereco_fornecedor`
  MODIFY `id_endereco_fornecedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=405;

--
-- AUTO_INCREMENT de tabela `endereco_funcionario`
--
ALTER TABLE `endereco_funcionario`
  MODIFY `id_endereco_funcionario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `estoque`
--
ALTER TABLE `estoque`
  MODIFY `id_estoque` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `forma_pagamento`
--
ALTER TABLE `forma_pagamento`
  MODIFY `id_forma_pagamento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `fornecedor`
--
ALTER TABLE `fornecedor`
  MODIFY `id_fornecedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=505;

--
-- AUTO_INCREMENT de tabela `funcionario`
--
ALTER TABLE `funcionario`
  MODIFY `id_funcionario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT de tabela `pedido`
--
ALTER TABLE `pedido`
  MODIFY `id_pedido` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `pedido_item`
--
ALTER TABLE `pedido_item`
  MODIFY `id_item` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `id_produto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de tabela `telefone_fornecedor`
--
ALTER TABLE `telefone_fornecedor`
  MODIFY `id_telefone_fornecedor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=406;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `venda`
--
ALTER TABLE `venda`
  MODIFY `id_venda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `contato_cliente`
--
ALTER TABLE `contato_cliente`
  ADD CONSTRAINT `contato_cliente_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`);

--
-- Restrições para tabelas `contato_funcionario`
--
ALTER TABLE `contato_funcionario`
  ADD CONSTRAINT `contato_funcionario` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id_funcionario`),
  ADD CONSTRAINT `contato_funcionario_ibfk_1` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id_funcionario`);

--
-- Restrições para tabelas `endereco_cliente`
--
ALTER TABLE `endereco_cliente`
  ADD CONSTRAINT `endereco_cliente_ibfk_1` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`);

--
-- Restrições para tabelas `endereco_fornecedor`
--
ALTER TABLE `endereco_fornecedor`
  ADD CONSTRAINT `endereco_fornecedor_ibfk_1` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedor` (`id_fornecedor`);

--
-- Restrições para tabelas `endereco_funcionario`
--
ALTER TABLE `endereco_funcionario`
  ADD CONSTRAINT `endereco_funcionario` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id_funcionario`),
  ADD CONSTRAINT `endereco_funcionario_ibfk_1` FOREIGN KEY (`id_funcionario`) REFERENCES `funcionario` (`id_funcionario`);

--
-- Restrições para tabelas `estoque`
--
ALTER TABLE `estoque`
  ADD CONSTRAINT `estoque_ibfk_1` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id_produto`),
  ADD CONSTRAINT `estoque_ibfk_2` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedor` (`id_fornecedor`);

--
-- Restrições para tabelas `funcionario`
--
ALTER TABLE `funcionario`
  ADD CONSTRAINT `funcionario_ibfk_1` FOREIGN KEY (`id_cargo`) REFERENCES `cargos` (`id_cargo`);

--
-- Restrições para tabelas `pedido_item`
--
ALTER TABLE `pedido_item`
  ADD CONSTRAINT `id_pedido` FOREIGN KEY (`id_pedido`) REFERENCES `pedido` (`id_pedido`),
  ADD CONSTRAINT `id_produto` FOREIGN KEY (`id_produto`) REFERENCES `produto` (`id_produto`),
  ADD CONSTRAINT `pedido_item` FOREIGN KEY (`id_pedido`) REFERENCES `pedido` (`id_pedido`);

--
-- Restrições para tabelas `produto`
--
ALTER TABLE `produto`
  ADD CONSTRAINT `produto_ibfk_1` FOREIGN KEY (`id_categoria`) REFERENCES `categoria` (`id_categoria`),
  ADD CONSTRAINT `produto_ibfk_2` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedor` (`id_fornecedor`);

--
-- Restrições para tabelas `telefone_fornecedor`
--
ALTER TABLE `telefone_fornecedor`
  ADD CONSTRAINT `telefone_fornecedor_ibfk_1` FOREIGN KEY (`id_fornecedor`) REFERENCES `fornecedor` (`id_fornecedor`);

--
-- Restrições para tabelas `venda`
--
ALTER TABLE `venda`
  ADD CONSTRAINT `forma_pagamento` FOREIGN KEY (`id_forma_pagamento`) REFERENCES `forma_pagamento` (`id_forma_pagamento`),
  ADD CONSTRAINT `idpedido` FOREIGN KEY (`id_pedido`) REFERENCES `pedido` (`id_pedido`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
